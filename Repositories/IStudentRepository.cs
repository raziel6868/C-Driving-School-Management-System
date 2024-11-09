using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
        void SaveStudent(Student Student);
        void DeleteStudent (Student Student);
        void UpdateStudent (Student Student);
        Student GetStudentById (int id);
        Student GetStudentByEmail(string email);

        int GetNewId();

        Student GetCurrentStudent();

        void UpdateCurrentStudent(Student Student);
    }
}
