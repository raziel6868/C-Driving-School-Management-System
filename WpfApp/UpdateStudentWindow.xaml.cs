using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for UpdateStudentWindow.xaml
    /// </summary>
    public partial class UpdateStudentWindow : Window
    {
        private IStudentRepository _StudentRepository = new StudentRepository();
        private int StudentID;
        public UpdateStudentWindow(int StudentId)
        {
            InitializeComponent();
            ComboStatus.ItemsSource = Enum.GetNames(typeof(StudentStatus));
            this.StudentID = StudentId;
            var c = _StudentRepository.GetStudentById(StudentId);
            this.DataContext = c;
            
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
           

            if (ComboStatus.SelectedItem != null)
            {
                string selectedStatusString = ComboStatus.SelectedItem.ToString();

                if (Enum.TryParse(selectedStatusString, out StudentStatus selectedStatus))
                {
                    var cus = new Student()
                    {
                        StudentStatus = selectedStatus,
                        StudentBirthday = DateTime.Parse(txtDate.Text),
                        StudentFullName = txtFullName.Text,
                        StudentID = StudentID,
                        EmailAddress = txtEmail.Text,
                        Password = txtPassword.Text,
                        Telephone = txtTelephone.Text,
                    };
                    _StudentRepository.UpdateStudent(
                         cus
                         );


                    MessageBox.Show("Student information updated successfully!");
                    this.Close();


                }
                else
                {
                    MessageBox.Show("Invalid Student status selected.");
                }
            }
            else
            {
                MessageBox.Show("Please select a Student status.");
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
                string selectedStatusString = ComboStatus.SelectedItem.ToString();
                if (Enum.TryParse(selectedStatusString, out StudentStatus selectedStatus))
                {
                    MessageBox.Show($"Selected Student Status Enum: {selectedStatus}");
                }

            }
        }
    }
}
