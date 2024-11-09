using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EnrollmentReservationRepository : IEnrollmentReservationRepository
    {
        public EnrollmentReservation AddReservation(EnrollmentReservation reservation)
        {
            return EnrollmentReservationDAO.Instance.AddReservation(reservation);
        }

        public void DeleteReservation(int reservationId)
        {
            EnrollmentReservationDAO.Instance.DeleteReservation(reservationId);
        }

        public List<EnrollmentReservation> GetAllReservations()
        {
            return EnrollmentReservationDAO.Instance.GetAllReservations();
        }

        public EnrollmentReservation GetEnrollmentReservation(int reservationId)
        {
           return EnrollmentReservationDAO.Instance.GetEnrollmentReservation(reservationId);
        }

        public void UpdateReservation(EnrollmentReservation updatedReservation)
        {
           EnrollmentReservationDAO.Instance.UpdateReservation(updatedReservation);
        }
    }
}
