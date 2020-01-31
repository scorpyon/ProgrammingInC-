using System;
using System.Text.RegularExpressions;

namespace GradesPrototype42.Data
{
    // Types of user
    public enum Role { Teacher, Student };

    // WPF Databinding requires properties

    public class Grade
    {
        public int StudentId { get; set; }

        // TODO: Exercise 2: Task 2a: Add validation to the AssessmentDate property
        private string _assessmentDate;
        public string AssessmentDate
        {
            get => _assessmentDate;
            set
            {
                if (DateTime.TryParse(value, out var date) && date <= DateTime.Now)
                {
                    _assessmentDate = date.ToShortDateString();
                }
                else
                {
                    throw new ArgumentException("Date was invalid.");
                }
            }
        }
        
        // TODO: Exercise 2: Task 2b: Add validation to the SubjectName property
        private string _subjectName;

        public string SubjectName
        {
            get => _subjectName;
            set
            {
                if (DataSource.Subjects.Contains(value))
                {
                    _subjectName = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect Subject entered.");
                }

            }
        }

        // TODO: Exercise 2: Task 2c: Add validation to the Assessment property
        private string _assessment;

        public string Assessment
        {
            get => _assessment;
            set
            {
                var matchGrade = Regex.Match(value, @"[A-E][+-]?$");
                if (matchGrade.Success)
                {
                    _assessment = value;
                }
                else
                {
                    throw new ArgumentException("Grade entered was invalid.");
                }
            }
        }

        public string Comments { get; set; }
                
        // Constructor to initialize the properties of a new Grade
        public Grade(int studentId, string assessmentDate, string subject, string assessment, string comments)
        {
            StudentId = studentId;
            AssessmentDate = assessmentDate;
            SubjectName = subject;
            Assessment = assessment;
            Comments = comments;
        }

        // Default constructor
        public Grade()
        {
            StudentId = 0;
            AssessmentDate = DateTime.Now.ToString("d");
            SubjectName = "Math";
            Assessment = "A";
            Comments = string.Empty;
        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string UserName { get; set; }

        private string _password = Guid.NewGuid().ToString(); // Generate a random password by default
        public string Password { 
            set 
            { 
                _password = value; 
            } 
        }

        public bool VerifyPassword(string pass)
        {
            return (String.Compare(pass, _password) == 0);
        }
        
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Constructor to initialize the properties of a new Student
        public Student(int studentID, string userName, string password, string firstName, string lastName, int teacherID)
        {
            StudentId = studentID;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            TeacherID = teacherID;
        }

        // Default constructor 
        public Student()
        {
            StudentId = 0;
            UserName = String.Empty;
            Password = String.Empty;
            FirstName = String.Empty;
            LastName = String.Empty;
            TeacherID = 0;
        }
    }

    public class Teacher
    {
        public int TeacherID { get; set; }
        public string UserName { get; set; }

        private string _password = Guid.NewGuid().ToString(); // Generate a random password by default
        public string Password
        {
            set
            {
                _password = value;
            }
        }

        public bool VerifyPassword(string pass)
        {
            return (String.Compare(pass, _password) == 0);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }

        // Constructor to initialize the properties of a new Teacher
        public Teacher(int teacherID, string userName, string password, string firstName, string lastName, string className)
        {
            TeacherID = teacherID;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Class = className;
        }

        // Default constructor
        public Teacher()
        {
            TeacherID = 0;
            UserName = String.Empty;
            Password = String.Empty;
            FirstName = String.Empty;
            LastName = String.Empty;
            Class = String.Empty;
        }
    }
}
