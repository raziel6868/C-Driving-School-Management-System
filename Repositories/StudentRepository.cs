using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private StudentDAO studentDAO = StudentDAO.Instance;

        public List<Student> GetAll() => studentDAO.GetAll();

        public Student GetByID(int studentID) => studentDAO.GetByID(studentID);

        public void Add(Student student) => studentDAO.Add(student);

        public void Update(Student student) => studentDAO.Update(student);

        public void Delete(int studentID) => studentDAO.Delete(studentID);

        public List<Student> GetStudentsByStatus(StudentStatus status)
            => studentDAO.GetAll().Where(s => s.StudentStatus == status).ToList();

        public List<Student> SearchStudents(string searchTerm)
            => studentDAO.GetAll().Where(s => s.StudentFullName.Contains(searchTerm) || s.Telephone.Contains(searchTerm)).ToList();

        public bool IsEmailUnique(string email)
            => !studentDAO.GetAll().Any(s => s.EmailAddress == email);

        public bool IsTelephoneUnique(string telephone)
            => !studentDAO.GetAll().Any(s => s.Telephone == telephone);
    }
}