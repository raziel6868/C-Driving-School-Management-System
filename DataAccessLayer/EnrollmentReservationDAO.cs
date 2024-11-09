using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class EnrollmentReservationDAO : SingletonBase<EnrollmentReservationDAO>
    {
        private List<EnrollmentReservation> reservations; 

        public EnrollmentReservationDAO()
        {
            reservations = new List<EnrollmentReservation>() { };
        }

        public List<EnrollmentReservation> GetAllReservations()
        {
            return reservations;
        }

        public EnrollmentReservation AddReservation(EnrollmentReservation reservation)
        {
            int newId = reservations.Count > 0 ? reservations.ToList().Max(r => r.EnrollmentReservationID) + 1 : 1;
            reservation.EnrollmentReservationID = newId;
            reservations.Add(reservation);
            return reservation;
        }

        public void UpdateReservation(EnrollmentReservation updatedReservation)
        {
            EnrollmentReservation existingReservation = reservations.ToList().FirstOrDefault(r => r.EnrollmentReservationID == updatedReservation.EnrollmentReservationID);
            if (existingReservation != null)
            {
                existingReservation.EnrollmentDate = updatedReservation.EnrollmentDate;
                existingReservation.TotalPrice = updatedReservation.TotalPrice;
                existingReservation.StudentID = updatedReservation.StudentID;
                existingReservation.Student = updatedReservation.Student;
                existingReservation.EnrollmentStatus = updatedReservation.EnrollmentStatus;
            }
        }

        public void DeleteReservation(int reservationId)
        {
            EnrollmentReservation reservationToRemove = reservations.ToList().FirstOrDefault(r => r.EnrollmentReservationID == reservationId);
            if (reservationToRemove != null)
            {
                reservations.Remove(reservationToRemove);
            }
        }

        public EnrollmentReservation GetEnrollmentReservation (int id)
        {
            return reservations.FirstOrDefault(x => x.EnrollmentReservationID == id) ?? null;
        }
    }
}
