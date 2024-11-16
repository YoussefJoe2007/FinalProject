using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         TaskContext context = new TaskContext();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            string role = check(email, password);
            if (role == "Student")
            {
                MessageBox.Show("Login successful as Student");
                StudentWindow studentWindow = new StudentWindow();
                studentWindow.Show();
                this.Close();

            }
            else if (role == "Teacher")
            {
                MessageBox.Show("Login successful as Teacher");
                TeacherWindow teacherWindow = new TeacherWindow();
                teacherWindow.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }

        }

        string check(string user_username, string user_password)
        {

            var user = context.Users.FirstOrDefault(u => u.useremail == user_username && u.userpassword == user_password);
            if (user == null)
            {
                return null;
            }
            return user.userrole;
        }
    }
}
