using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentFullName { get; set; }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }
        public DateTime StudentBirthday { get; set; }
        public StudentStatus StudentStatus { get; set; }
        public string Password { get; set; }
    }
}
