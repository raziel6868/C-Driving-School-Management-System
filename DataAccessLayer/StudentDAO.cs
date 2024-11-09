using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class StudentDAO : SingletonBase<StudentDAO>
    {
        Student CurrentStudent = new Student();
        List<Student> list = new List<Student>()
            {
                new Student
                {
                    StudentID = 1,
                    StudentFullName = "John Doe",
                    Telephone = "1234567890",
                    EmailAddress = "john.doe@example.com",
                    StudentBirthday = new DateTime(1990, 1, 1),
                    StudentStatus = StudentStatus.Active,
                    Password = "password123"
                },
                new Student
                {
                    StudentID = 2,
                    StudentFullName = "Jane Smith",
                    Telephone = "0987654321",
                    EmailAddress = "jane.smith@example.com",
                    StudentBirthday = new DateTime(1985, 5, 15),
                    StudentStatus = StudentStatus.Active,
                    Password = "password456"
                },
                new Student
                {
                    StudentID = 3,
                    StudentFullName = "Michael Johnson",
                    Telephone = "1231231234",
                    EmailAddress = "michael.johnson@example.com",
                    StudentBirthday = new DateTime(1978, 8, 20),
                    StudentStatus = StudentStatus.Active,
                    Password = "password789"
                },
                new Student
                {
                    StudentID = 4,
                    StudentFullName = "Emily Davis",
                    Telephone = "4564564567",
                    EmailAddress = "emily.davis@example.com",
                    StudentBirthday = new DateTime(1995, 3, 10),
                    StudentStatus = StudentStatus.Active,
                    Password = "password101"
                },
                new Student
                {
                    StudentID = 5,
                    StudentFullName = "William Brown",
                    Telephone = "7897897890",
                    EmailAddress = "william.brown@example.com",
                    StudentBirthday = new DateTime(1982, 12, 25),
                    StudentStatus = StudentStatus.Active,
                    Password = "password102"
                },
                new Student
                {
                    StudentID = 6,
                    StudentFullName = "Olivia Wilson",
                    Telephone = "1472583690",
                    EmailAddress = "olivia.wilson@example.com",
                    StudentBirthday = new DateTime(1991, 6, 30),
                    StudentStatus = StudentStatus.Active,
                    Password = "password103"
                },
                new Student
                {
                    StudentID = 7,
                    StudentFullName = "James Taylor",
                    Telephone = "3216549870",
                    EmailAddress = "james.taylor@example.com",
                    StudentBirthday = new DateTime(1988, 11, 11),
                    StudentStatus = StudentStatus.Active,
                    Password = "password104"
                },
                new Student
                {
                    StudentID = 8,
                    StudentFullName = "Isabella Anderson",
                    Telephone = "3692581470",
                    EmailAddress = "isabella.anderson@example.com",
                    StudentBirthday = new DateTime(1993, 2, 20),
                    StudentStatus = StudentStatus.Active,
                    Password = "password105"
                },
                new Student
                {
                    StudentID = 9,
                    StudentFullName = "Liam Thomas",
                    Telephone = "8529637410",
                    EmailAddress = "liam.thomas@example.com",
                    StudentBirthday = new DateTime(1987, 4, 14),
                    StudentStatus = StudentStatus.Active,
                    Password = "password106"
                },
                new Student
                {
                    StudentID = 10,
                    StudentFullName = "Sophia Martinez",
                    Telephone = "9637412580",
                    EmailAddress = "sophia.martinez@example.com",
                    StudentBirthday = new DateTime(1992, 9, 19),
                    StudentStatus = StudentStatus.Active,
                    Password = "password107"
                }
            };

        public Student GetCurrentStudent()
        {
            return CurrentStudent;
        }
        public List<Student> GetStudents()
        {
            
            return list;
        }

        public void AddStudent (Student Student)
        {
            list.Add(Student);
        }

        public void UpdateCurrentStudent(Student Student)
        {
            CurrentStudent = Student;
        }
        public void UpdateStudent (Student Student)
        {
            foreach (var current in list.ToList()) {
                if (current.StudentID == Student.StudentID)
                {
                    current.StudentFullName = Student.StudentFullName;
                    current.Telephone = Student.Telephone;
                    current.EmailAddress = Student.EmailAddress;
                    current.StudentBirthday = Student.StudentBirthday;
                    current.StudentStatus = Student.StudentStatus;
                    current.Password = Student.Password;
                }
            }
        }

        public void DeleteStudent(Student Student)
        {
            foreach (var current in list.ToList())
            {
                if (current.StudentID == Student.StudentID)
                {
                    list.Remove(current);
                }
            }
        }

        public Student GetStudentById (int id)
        {
            foreach (var current in list)
            {
                if (current.StudentID == id)
                {
                    return current;
                }
               
            }
            return null;
        }

        public Student GetStudentByEmail (string email)
        {
            foreach (var current in list)
            {
                if (current.EmailAddress.Equals(email))
                {
                    CurrentStudent = current;
                    return current;
                }
            }
            return null;
        }

        public int GetNewId ()
        {
            return list.Max(x => x.StudentID) + 1;
        }
        
    }
}
