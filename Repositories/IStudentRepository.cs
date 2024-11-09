using System.Collections.Generic;
using BusinessObjects;

namespace Repositories
{
    public interface IStudentRepository
    {
        Student GetStudentByEmail(string email);
        List<Student> GetAll();
        Student GetByID(int studentID);
        void Add(Student student);
        void Update(Student student);
        void Delete(int studentID);
        List<Student> GetStudentsByStatus(StudentStatus status);
        List<Student> SearchStudents(string searchTerm);
        bool IsEmailUnique(string email);
        bool IsTelephoneUnique(string telephone);
    }
}