using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Student.xaml
    /// </summary>
    public partial class StudentWindow : Window, INotifyPropertyChanged
    {
        private IStudentRepository _StudentRepository = new StudentRepository();
        private IEnrollmentReservationRepository _EnrollmentReservationRepository = new EnrollmentReservationRepository();
        private IEnrollmentDetailRepository _EnrollmentDetailRepository = new EnrollmentDetailRepository();
        private ICourseInformationRepository _CourseInformationRepository = new CourseInfomationRepository();
        
        private List<CourseInformation> _CourseLists;
        public List<CourseInformation> CourseLists
        {
            get { return _CourseLists; }
            set
            {
                _CourseLists = value;
                OnPropertyChanged(nameof(CourseLists));
            }
        }

        private CourseInformation _selectedCourse;
        public CourseInformation SelectedCourse
        {
            get { return _selectedCourse; }
            set
            {
                if (_selectedCourse != value)
                {
                    _selectedCourse = value;
                    OnPropertyChanged(nameof(SelectedCourse));

                    if (_selectedCourse != null)
                    {
                        CoursePricePerDate = _selectedCourse.CoursePricePerDate;
                    }
                }
            }
        }


        private decimal _CoursePricePerDate;
        public decimal CoursePricePerDate
        {
            get { return _CoursePricePerDate; }
            set
            {
                if (_CoursePricePerDate != value)
                {
                    _CoursePricePerDate = value;
                    OnPropertyChanged(nameof(CoursePricePerDate));
                    CalculateActualPrice(); // Recalculate ActualPrice when CoursePricePerDate changes

                    if (SelectedCourse != null)
                    {
                        SelectedCourse.CoursePricePerDate = _CoursePricePerDate;
                        OnPropertyChanged(nameof(SelectedCourse)); // Notify SelectedCourse change
                    }
                }
            }
        }

        private Student _Student;
        public Student Student
        {
            get { return _Student; }
            set
            {
                _Student = value;
                OnPropertyChanged(nameof(Student));
            }
        }

        private DateTime _startTime = DateTime.Now;
        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged(nameof(StartTime));
                CalculateActualPrice(); // Recalculate ActualPrice when StartTime changes
            }
        }

        private DateTime _endTime = DateTime.Now;
        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                OnPropertyChanged(nameof(EndTime));
                CalculateActualPrice(); // Recalculate ActualPrice when EndTime changes
            }
        }
        private decimal _actualPrice = 0;
        public decimal ActualPrice
        {
            get => _actualPrice;
            set
            {
                _actualPrice = value;
                OnPropertyChanged(nameof(ActualPrice));
                CalculateTotalPrice();
            }
        }

        private decimal _totalPrice = 0;
        public decimal TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }
        private void CalculateActualPrice()
        {
            int days = (EndTime.Date - StartTime.Date).Days + 1;
            ActualPrice = CoursePricePerDate * days;
        }

        private void CalculateTotalPrice()
        {
            decimal taxRate = 0.08m; 
            TotalPrice = ActualPrice * (1 + taxRate);
        }

        public StudentWindow()
        {
            InitializeComponent();
            DataContext = this;

            BindStudent();
            CourseLists = _CourseInformationRepository.GetCourseInformations();

            cbCourse.ItemsSource = CourseLists;
            cbCourse.DisplayMemberPath = "CourseNumber";
            BindEnrollmentDetails();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void BindStudent()
        {
            Student = _StudentRepository.GetCurrentStudent();
        }

        private void BindEnrollmentDetails()
        {
            dtEnrollmentDetails.ItemsSource = _EnrollmentDetailRepository.GetEnrollmentDetails(Student.StudentID);
            dtEnrollmentDetails.Items.Refresh();

        }


        private void cbCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedCourse = cbCourse.SelectedItem as CourseInformation;
        }

        private void  ButtonBook_Click(object sender, RoutedEventArgs e)
        {
            EnrollmentReservation EnrollmentReservation = new EnrollmentReservation()
            {
                EnrollmentDate = DateTime.Now,
                TotalPrice = Decimal.Parse(txtTotalPrice.Text),
                EnrollmentReservationID = 0,
                EnrollmentStatus = EnrollmentStatus.Pending,
                StudentID = Student.StudentID,
                Student = Student,
            };
            var newEnrollmentReservation = _EnrollmentReservationRepository.AddReservation(EnrollmentReservation);
            var list = _EnrollmentReservationRepository.GetAllReservations();
            EnrollmentDetail EnrollmentDetail = new EnrollmentDetail()
            {
                ActualPrice = Decimal.Parse(txtActualPrice.Text),
                EnrollmentReservation = newEnrollmentReservation,
                EnrollmentReservationID = newEnrollmentReservation.EnrollmentReservationID,
                EndDate = DateTime.Parse(txtEndDate.Text),
                CourseID = SelectedCourse.CourseID,
                CourseInformation = SelectedCourse,
                StartDate = DateTime.Parse(txtStartDate.Text),
            };
            _EnrollmentDetailRepository.AddEnrollmentDetail(EnrollmentDetail);
            var list1 = _EnrollmentDetailRepository.GetAllEnrollmentDetails();

            MessageBox.Show("Book Course successfully, waiting for admin to confirm your Enrollment");
            BindEnrollmentDetails();
        }

      

        private void ButtonLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            UpdateProfile updateWindow = new UpdateProfile();
            updateWindow.Owner = Window.GetWindow(this);
            updateWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            updateWindow.Closed += (s, args) =>
            {
                BindStudent();

            };

            updateWindow.ShowDialog();
        }
    }
}

