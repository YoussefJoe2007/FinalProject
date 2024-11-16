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
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    
    public partial class StudentWindow : Window
    {
        TaskContext task=new TaskContext();
        public StudentWindow()
        {
            InitializeComponent();
            ShowUncompletedTasks();
            ShowCompletedTasks();
        }

       


        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            Course obj= new Course();
            obj.courseid = int.Parse(TaskIdTextBox.Text);
            Course result= task.Courses.Find(obj.courseid);
            if (result != null)
            {
                result.coursestatus = StatusComboBox.Text;
                task.SaveChanges();
                ShowUncompletedTasks();// for completed status
                ShowCompletedTasks();// for uncompleted status


                MessageBox.Show("trying to save the state");
            }
            else { MessageBox.Show("can not save the state"); }

          

          
            

        }



            private void BackButton_Click(object sender, RoutedEventArgs e)
            {
                MainWindow login = new MainWindow();
                login.Show();
                this.Close();
            }

            private void LogoutButton_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }
        
    



    void ShowUncompletedTasks()
        {
            Grid1.ItemsSource = task.Courses.Where(t => t.coursestatus == "In Progress" || t.coursestatus == "Pending").ToList();
        }

        void ShowCompletedTasks()
        {
            Grid2.ItemsSource = task.Courses.Where(t => t.coursestatus == "Completed").ToList();
        }

      
    }
}
