using System.Windows;
using BusinessObjects;
using DataAccessLayer;
using Repositories;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStudentRepository studentRepository;

        public MainWindow()
        {
            InitializeComponent();
            studentRepository = new StudentRepository();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;

            Student student = studentRepository.GetStudentByEmail(email);

            if (student != null && student.Password == password)
            {
                MessageBox.Show("Login successful!");
                StudentWindow studentWindow = new StudentWindow(
                    new StudentRepository(),
                    new CourseInformationRepository(),
                    new EnrollmentReservationRepository()
                );
                studentWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.");
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow(studentRepository);
            registerWindow.Show();
            this.Close();
        }
    }
}