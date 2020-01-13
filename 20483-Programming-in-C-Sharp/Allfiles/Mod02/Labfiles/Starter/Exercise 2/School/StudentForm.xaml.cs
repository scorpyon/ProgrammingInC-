using System;
using System.Windows;

namespace School
{
    /// <summary>
    /// Interaction logic for StudentForm.xaml
    /// </summary>
    public partial class StudentForm : Window
    {
        #region Predefined code

        public StudentForm()
        {
            InitializeComponent();
        }

        #endregion

        // If the user clicks OK to save the Student details, validate the information that the user has provided
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Exercise 2: Task 2a: Check that the user has provided a first name
            if (firstName.Text == string.Empty)
            {
                MessageBox.Show("Students must have a first name.", "Error!");
                return;
            }

            // TODO: Exercise 2: Task 2b: Check that the user has provided a last name
            if (lastName.Text == string.Empty)
            {
                MessageBox.Show("Students must have a last name.", "Error!");
                return;
            }

            // TODO: Exercise 2: Task 3a: Check that the user has entered a valid date for the date of birth
            DateTime date;
            if (dateOfBirth.Text == string.Empty || !DateTime.TryParse(dateOfBirth.Text, out date))
            {
                MessageBox.Show("Students must have a valid date of birth.", "Error!");
                return;
            }

            // TODO: Exercise 2: Task 3b: Verify that the student is at least 5 years old
            var ageInYears = (int)((DateTime.Now - date).Days / 365.25);
            if (ageInYears < 5)
            {
                MessageBox.Show("Students must be at least 5 years old.", "Error!");
                return;
            }

            // Indicate that the data is valid
            this.DialogResult = true;
        }
    }
}
