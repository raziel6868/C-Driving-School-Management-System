using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IEnrollmentReservationRepository
    {
        List<EnrollmentReservation> GetAllReservations();
        EnrollmentReservation AddReservation(EnrollmentReservation reservation);
        void UpdateReservation(EnrollmentReservation updatedReservation);
        void DeleteReservation(int reservationId);
        EnrollmentReservation GetEnrollmentReservation(int reservationId);

    }
}
