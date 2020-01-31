using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GradesPrototype.Data;
using GradesPrototype.Services;

namespace GradesPrototype.Controls
{
    /// <summary>
    /// Interaction logic for AssignStudentDialog.xaml
    /// </summary>
    public partial class AssignStudentDialog : Window
    {
        public AssignStudentDialog()
        {
            InitializeComponent();
        }

        // TODO: Exercise 4: Task 3b: Refresh the display of unassigned students
        private void Refresh()
        {
            var unassignedStudents = DataSource.Students.Where(x => x.TeacherID == 0).ToList();
            if(unassignedStudents.Count < 1)
            {
                txtMessage.Visibility = Visibility.Visible;
                list.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtMessage.Visibility = Visibility.Hidden;
                list.Visibility = Visibility.Visible;
                list.ItemsSource = unassignedStudents;
            }
        }

        private void AssignStudentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        // TODO: Exercise 4: Task 3a: Enroll a student in the teacher's class
        private void Student_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var studentId = int.Parse(((Button) sender).Tag.ToString());
                var student = DataSource.Students.FirstOrDefault(s => s.StudentID == studentId);
                if (student == null || MessageBox.Show(
                        $"Do you want to add {student.FirstName} {student.LastName} to {SessionContext.CurrentTeacher.FirstName} {SessionContext.CurrentTeacher.LastName}'s class?",
                        "Add Student", MessageBoxButton.OKCancel) != MessageBoxResult.OK)
                {
                    return;
                }

                SessionContext.CurrentStudent = student;
                SessionContext.CurrentTeacher.EnrollInClass();
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error trying to add the student to the class.");
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            // Close the dialog box
            this.Close();
        }
    }
}
