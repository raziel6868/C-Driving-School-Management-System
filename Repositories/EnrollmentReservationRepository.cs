using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class EnrollmentReservationRepository : IEnrollmentReservationRepository
    {
        private EnrollmentReservationDAO enrollmentReservationDAO = EnrollmentReservationDAO.Instance;

        public List<EnrollmentReservation> GetAll() => enrollmentReservationDAO.GetAll();

        public EnrollmentReservation GetByID(int enrollmentID) => enrollmentReservationDAO.GetByID(enrollmentID);

        public void Add(EnrollmentReservation enrollment) => enrollmentReservationDAO.Add(enrollment);

        public void Update(EnrollmentReservation enrollment) => enrollmentReservationDAO.Update(enrollment);

        public void Delete(int enrollmentID) => enrollmentReservationDAO.Delete(enrollmentID);

        public List<EnrollmentReservation> GetEnrollmentsByStudentID(int studentID)
            => enrollmentReservationDAO.GetAll().Where(e => e.StudentID == studentID).ToList();

        public List<EnrollmentReservation> GetEnrollmentsByCourseID(int courseID)
            => enrollmentReservationDAO.GetAll().Where(e => e.CourseID == courseID).ToList();

        public List<EnrollmentReservation> GetEnrollmentsByDateRange(DateTime startDate, DateTime endDate)
            => enrollmentReservationDAO.GetAll().Where(e => e.EnrollmentDate >= startDate && e.EnrollmentDate <= endDate).ToList();

        public bool IsStudentEnrolledInCourse(int studentID, int courseID)
            => enrollmentReservationDAO.GetAll().Any(e => e.StudentID == studentID && e.CourseID == courseID);

        public int GetEnrollmentCountForCourse(int courseID)
            => enrollmentReservationDAO.GetAll().Count(e => e.CourseID == courseID);
    }
}