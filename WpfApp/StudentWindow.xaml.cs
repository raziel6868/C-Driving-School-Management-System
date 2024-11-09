using System;
using System.Windows;
using System.Windows.Controls;
using BusinessObjects;
using Repositories;
using System.Linq;

namespace WpfApp
{
    public partial class StudentWindow : Window
    {
        private IStudentRepository studentRepository;
        private ICourseInformationRepository courseInformationRepository;
        private IEnrollmentReservationRepository enrollmentReservationRepository;

        private Student currentStudent;
        private bool isNewStudent = false;

        public StudentWindow(IStudentRepository stuRepo, ICourseInformationRepository courseInfoRepo,
                             IEnrollmentReservationRepository enrollRepo)
        {
            InitializeComponent();
            studentRepository = stuRepo;
            courseInformationRepository = courseInfoRepo;
            enrollmentReservationRepository = enrollRepo;

            LoadStudents();
            SetupStatusComboBox();
        }

        private void SetupStatusComboBox()
        {
            cboStatus.ItemsSource = Enum.GetValues(typeof(StudentStatus));
        }

        private void LoadStudents()
        {
            dgStudents.ItemsSource = studentRepository.GetAll();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            isNewStudent = true;
            EnableFields(true);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgStudents.SelectedItem != null)
            {
                currentStudent = (Student)dgStudents.SelectedItem;
                DisplayStudentDetails(currentStudent);
                isNewStudent = false;
                EnableFields(true);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một học viên để chỉnh sửa.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgStudents.SelectedItem != null)
            {
                Student studentToDelete = (Student)dgStudents.SelectedItem;
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa học viên này?", "Xác nhận xóa", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    studentRepository.Delete(studentToDelete.StudentID);
                    LoadStudents();
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một học viên để xóa.");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                if (isNewStudent)
                {
                    currentStudent = new Student();
                }

                currentStudent.StudentFullName = txtFullName.Text;
                currentStudent.Telephone = txtTelephone.Text;
                currentStudent.EmailAddress = txtEmail.Text;
                currentStudent.StudentBirthday = dpBirthday.SelectedDate ?? DateTime.Now;
                currentStudent.StudentStatus = (StudentStatus)cboStatus.SelectedItem;

                if (isNewStudent)
                {
                    studentRepository.Add(currentStudent);
                }
                else
                {
                    studentRepository.Update(currentStudent);
                }

                LoadStudents();
                ClearFields();
                EnableFields(false);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            EnableFields(false);
        }

        private void DisplayStudentDetails(Student student)
        {
            txtStudentID.Text = student.StudentID.ToString();
            txtFullName.Text = student.StudentFullName;
            txtTelephone.Text = student.Telephone;
            txtEmail.Text = student.EmailAddress;
            dpBirthday.SelectedDate = student.StudentBirthday;
            cboStatus.SelectedItem = student.StudentStatus;

            LoadStudentCourses(student.StudentID);
        }

        private void LoadStudentCourses(int studentId)
        {
            var enrollments = enrollmentReservationRepository.GetAll()
                .Where(e => e.StudentID == studentId)
                .ToList();

            var courseIds = enrollments.Select(e => e.CourseID).Distinct().ToList();
            var courses = courseInformationRepository.GetAll()
                .Where(c => courseIds.Contains(c.CourseID))
                .ToList();

            dgCourses.ItemsSource = courses;
        }

        private void ClearFields()
        {
            txtStudentID.Clear();
            txtFullName.Clear();
            txtTelephone.Clear();
            txtEmail.Clear();
            dpBirthday.SelectedDate = null;
            cboStatus.SelectedIndex = -1;

            dgCourses.ItemsSource = null;
        }

        private void EnableFields(bool enable)
        {
            txtFullName.IsEnabled = enable;
            txtTelephone.IsEnabled = enable;
            txtEmail.IsEnabled = enable;
            dpBirthday.IsEnabled = enable;
            cboStatus.IsEnabled = enable;

            btnSave.IsEnabled = enable;
            btnCancel.IsEnabled = enable;
            btnAdd.IsEnabled = !enable;
            btnEdit.IsEnabled = !enable;
            btnDelete.IsEnabled = !enable;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên đầy đủ của học viên.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại của học viên.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ email của học viên.");
                return false;
            }

            if (!dpBirthday.SelectedDate.HasValue)
            {
                MessageBox.Show("Vui lòng chọn ngày sinh của học viên.");
                return false;
            }

            if (cboStatus.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái của học viên.");
                return false;
            }

            return true;
        }

        private void dgStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgStudents.SelectedItem != null)
            {
                currentStudent = (Student)dgStudents.SelectedItem;
                DisplayStudentDetails(currentStudent);
            }
        }
    }
}