using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public void DeleteStudent(Student Student)
        {
            StudentDAO.Instance.DeleteStudent(Student);
        }

        public Student GetStudentById(int id)
        {
            return StudentDAO.Instance.GetStudentById(id);
        }

        public List<Student> GetStudents()
        {
            return StudentDAO.Instance.GetStudents();
        }

        public void SaveStudent(Student Student)
        {
            StudentDAO.Instance.AddStudent(Student);
        }

        public void UpdateStudent(Student Student)
        {
            StudentDAO.Instance.UpdateStudent(Student);
        }

        public Student GetStudentByEmail (string email)
        {
            return StudentDAO.Instance.GetStudentByEmail(email);
        }

        public int GetNewId()
        {
            return StudentDAO.Instance.GetNewId();
        }

        public Student GetCurrentStudent()
        {
            return StudentDAO.Instance.GetCurrentStudent();
        }

        public void UpdateCurrentStudent(Student Student)
        {
            StudentDAO.Instance.UpdateStudent(Student);
        }
    }
}
