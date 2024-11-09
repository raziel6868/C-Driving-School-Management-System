using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class EnrollmentDetail
    {
        public int EnrollmentReservationID { get; set; }
        public EnrollmentReservation EnrollmentReservation { get; set; }
        public int CourseID { get; set; }
        public CourseInformation CourseInformation {  get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal ActualPrice { get; set; }
    }
}
