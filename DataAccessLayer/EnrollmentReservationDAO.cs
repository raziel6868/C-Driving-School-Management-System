using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class EnrollmentReservationDAO : SingletonBase<EnrollmentReservationDAO>
    {
        private List<EnrollmentReservation> list;

        public EnrollmentReservationDAO()
        {
            list = new List<EnrollmentReservation>();
        }

        public List<EnrollmentReservation> GetAll() => list;

        public EnrollmentReservation GetByID(int enrollmentID) => list.FirstOrDefault(e => e.EnrollmentReservationID == enrollmentID);

        public void Add(EnrollmentReservation enrollment)
        {
            enrollment.EnrollmentReservationID = GetNewId();
            list.Add(enrollment);
        }

        public void Update(EnrollmentReservation enrollment)
        {
            var index = list.FindIndex(e => e.EnrollmentReservationID == enrollment.EnrollmentReservationID);
            if (index != -1)
            {
                list[index] = enrollment;
            }
        }

        public void Delete(int enrollmentID)
        {
            var enrollment = GetByID(enrollmentID);
            if (enrollment != null)
            {
                list.Remove(enrollment);
            }
        }

        private int GetNewId() => list.Count == 0 ? 1 : list.Max(e => e.EnrollmentReservationID) + 1;
    }
}
