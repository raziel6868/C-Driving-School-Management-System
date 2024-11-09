using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class EnrollmentReservation
    {
        public int EnrollmentReservationID {  get; set; }
        public DateTime EnrollmentDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public EnrollmentStatus EnrollmentStatus { get; set; }

    }
}
