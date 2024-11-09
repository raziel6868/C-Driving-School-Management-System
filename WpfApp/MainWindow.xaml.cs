using Repositories;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string emailConfig = App.Configuration["AdminAccount:Email"];
        private string passwordConfig = App.Configuration["AdminAccount:Password"];
        private readonly IStudentRepository _StudentRepository = new StudentRepository();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnStudentManagement_Click(object sender, RoutedEventArgs e)
        {
            StudentWindow studentWindow = new StudentWindow(
                new StudentRepository(),
                new CourseInformationRepository(),
                new EnrollmentReservationRepository()
            );
            studentWindow.Show();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = txtUserName.Text;
            string password = txtPass.Password;

            
            var Student = _StudentRepository.GetStudentByEmail(email);

            if (Student != null && Student.Password == password)
            {
                MessageBox.Show("Login successful!");
                this.Hide();
                StudentWindow StudentWindow = new StudentWindow();
                StudentWindow.Show();
            }
            else if (Student == null && emailConfig.Equals(txtUserName.Text))
            {
                //MessageBox.Show("Login admin successful!");
                this.Hide();
                Admin adminWindow = new Admin();
                adminWindow.Show();
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
            }
        }
    }
}

