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
    /// Interaction logic for UpdateProfile.xaml
    /// </summary>
    public partial class UpdateProfile : Window
    {
        private IStudentRepository _StudentRepository = new StudentRepository();
        public Student Student { get; set; } = new Student();
        public UpdateProfile()
        {
            InitializeComponent();
            Student = _StudentRepository.GetCurrentStudent();
            this.DataContext = Student;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {



            var cus = new Student()
            {
                StudentStatus = Student.StudentStatus,
                StudentBirthday = DateTime.Parse(txtDate.Text),
                StudentFullName = txtFullName.Text,
                StudentID = Student.StudentID,
                EmailAddress = txtEmail.Text,
                Password = txtPassword.Text,
                Telephone = txtTelephone.Text,
            };
            _StudentRepository.UpdateStudent(
                 cus
                 );
            _StudentRepository.UpdateCurrentStudent(cus);

            this.Close();
            MessageBox.Show("Student information updated successfully!");

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
