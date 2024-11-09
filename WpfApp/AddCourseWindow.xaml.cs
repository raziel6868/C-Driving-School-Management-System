using BusinessObjects;
using Repositories;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for UpdateCourseWindow.xaml
    /// </summary>
    public partial class AddCourseWindow : Window
    {
        private ICourseTypeRepository _CourseTypeRepository = new CourseTypeRepository();
        private ICourseInformationRepository _CourseInformationRepository = new CourseInfomationRepository();
        public AddCourseWindow()
        {
            InitializeComponent();
            ComboBox.ItemsSource = _CourseTypeRepository.GetCourseTypes();
            ComboStatus.ItemsSource = Enum.GetNames(typeof(CourseStatus));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection change here
            if (ComboBox.SelectedItem != null)
            {
                CourseType selectedCourseType = (CourseType)ComboBox.SelectedItem;
                MessageBox.Show($"Selected Course Type: {selectedCourseType.CourseTypeName}");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
            CourseType selectedCourseType = (CourseType)ComboBox.SelectedItem;

            
            if (ComboStatus.SelectedItem != null)
            {
                string selectedStatusString = ComboStatus.SelectedItem.ToString();

                if (Enum.TryParse(selectedStatusString, out CourseStatus selectedStatus))
                {
                    CourseInformation Course = new CourseInformation()
                    {
                        CourseStatus = selectedStatus,
                        CourseType = selectedCourseType,
                        CourseTypeID = selectedCourseType.CourseTypeID,
                        CourseID = _CourseInformationRepository.GetNewId(),
                        CourseDescription = txtCourseDesc.Text,
                        CourseMaxCapacity = int.Parse(txtCourseMaxCapacity.Text),
                        CourseNumber = txtCourseNumber.Text,
                        CoursePricePerDate = decimal.Parse(txtCoursePrice.Text),
                    };
                    _CourseInformationRepository.SaveCourseInformation(
                         Course
                         );


                    MessageBox.Show("Course information added successfully!");
                    this.Close();


                }
                else
                {
                    MessageBox.Show("Invalid Course status selected.");
                }
            }
            else
            {
                MessageBox.Show("Please select a Course status.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void ComboBox_SelectionChangedStatus(object sender, SelectionChangedEventArgs e)
        {
            if (ComboStatus.SelectedItem != null)
            {
                // Lấy chuỗi đại diện cho enum từ ComboBox
                string selectedStatusString = ComboStatus.SelectedItem.ToString();

                // Chuyển đổi chuỗi thành enum CourseStatus
                if (Enum.TryParse(selectedStatusString, out CourseStatus selectedStatus))
                {
                    MessageBox.Show($"Selected Course Status Enum: {selectedStatus}");
                    // Bạn có thể sử dụng giá trị enum selectedStatus ở đây
                }

            }
        }
    }
}
