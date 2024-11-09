using System;
using System.Collections.Generic;
using BusinessObjects;

namespace Repositories
{
    public interface IEnrollmentReservationRepository
    {
        List<EnrollmentReservation> GetAll();
        EnrollmentReservation GetByID(int enrollmentID);
        void Add(EnrollmentReservation enrollment);
        void Update(EnrollmentReservation enrollment);
        void Delete(int enrollmentID);
        List<EnrollmentReservation> GetEnrollmentsByStudentID(int studentID);
        List<EnrollmentReservation> GetEnrollmentsByCourseID(int courseID);
        List<EnrollmentReservation> GetEnrollmentsByDateRange(DateTime startDate, DateTime endDate);
        bool IsStudentEnrolledInCourse(int studentID, int courseID);
        int GetEnrollmentCountForCourse(int courseID);
    }
}