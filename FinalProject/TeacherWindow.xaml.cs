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

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : Window
    {
        TaskContext taskContext = new TaskContext();
        public TeacherWindow()
        {
            InitializeComponent();
            CoursesDataGrid.ItemsSource = taskContext.Courses.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Course courseObj = new Course();
            courseObj.coursetitle = Title.Text;
            courseObj.coursedescription = Description.Text;
            courseObj.coursestatus = Status.Text;
            taskContext.Courses.Add(courseObj);
            taskContext.SaveChanges();
            MessageBox.Show("Course has been added successfully");
            DisplayData();

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Course courseObj2 = new Course();
            courseObj2.courseid = int.Parse(CourseId.Text);
            Course course = taskContext.Courses.Find(courseObj2.courseid);
            if (course != null)
            {
                taskContext.Courses.Remove(course);
                taskContext.SaveChanges();
                MessageBox.Show("Course deleted successfully.");
            }
            else
            {
                MessageBox.Show("Course not found.");
            }
            DisplayData();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Course courseObj3 = new Course();
            courseObj3.courseid = int.Parse(CourseId.Text);
            Course course = taskContext.Courses.Find(courseObj3.courseid);
            if (course != null)
            { 
            course.coursetitle = Title.Text;
            course.coursedescription = Description.Text;
                 
                taskContext.SaveChanges();

            DisplayData();
            MessageBox.Show("Course updated successfully.");
        }
          else
    {
        MessageBox.Show("Course not found.");
    }

}

        void DisplayData()
        {
            CoursesDataGrid.ItemsSource= taskContext.Courses.ToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logout successful.");
            this.Close();
        }
    }
}
