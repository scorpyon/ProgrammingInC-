using System;
using System.Windows.Controls;

namespace GradesPrototype.Data
{
    // Types of user
    public enum Role { Teacher, Student };

    // WPF Databinding requires properties

    // TODO: Exercise 1: Task 1a: Convert Grade into a class and define constructors
    public class Grade
    {
        public int StudentID { get; set; }
        public string AssessmentDate { get; set; }
        public string SubjectName { get; set; }
        public string Assessment { get; set; }
        public string Comments { get; set; }

        public Grade()
        {
            StudentID = 0;
            AssessmentDate = DateTime.Now.ToShortDateString();
            SubjectName = "Maths";
            Assessment = "A";
            Comments = string.Empty;
        }

        public Grade(int studentId, string assessmentDate, string subject, string assessment, string comments)
        {
            StudentID = studentId;
            AssessmentDate = assessmentDate;
            SubjectName = subject;
            Assessment = assessment;
            Comments = comments;
        }
    }

    // TODO: Exercise 1: Task 2a: Convert Student into a class, make the password property write-only, add the VerifyPassword method, and define constructors
    public class Student
    {
        public int StudentID { get; set; }
        public string UserName { get; set; }
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private string _password = new Guid().ToString();

        public string Password
        {
            set => _password = value;
        }

        public Student()
        {
            StudentID = 0;
            UserName = string.Empty;
            Password = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            TeacherID = 0;
        }

        public Student(int studentId, string userName, string password, string firstName, string lastName, int teacherId)
        {
            StudentID = studentId;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            TeacherID = teacherId;
        }

        public int VerifyPassword(string password)
        {
            return string.CompareOrdinal(_password, password);
        }
    }

    // TODO: Exercise 1: Task 2b: Convert Teacher into a class, make the password property write-only, add the VerifyPassword method, and define constructors
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        private string _password = new Guid().ToString();

        public string Password
        {
            set => _password = value;
        }

        public Teacher()
        {
            TeacherID = 0;
            UserName = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Password = string.Empty;
            Class = string.Empty;
        }

        public Teacher(int teacherId, string userName, string password, string firstName, string lastName, string className)
        {
            TeacherID = teacherId;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Class = className;
        }

        public int VerifyPassword(string password)
        {
            return string.CompareOrdinal(_password, password);
        }
    }
}
