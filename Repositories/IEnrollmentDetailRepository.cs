using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IEnrollmentDetailRepository
    {
        List<EnrollmentDetail> GetAllEnrollmentDetails();
        EnrollmentDetail GetEnrollmentDetail(int EnrollmentReservationId);
        void AddEnrollmentDetail(EnrollmentDetail EnrollmentDetail);
        void UpdateEnrollmentDetail(EnrollmentDetail updatedEnrollmentDetail);
        void DeleteEnrollmentDetail(int EnrollmentReservationId, int CourseId);
        List<CourseInformation> GetAvailableCourses();
        List<EnrollmentDetail> GetEnrollmentDetails(int userId);
    }
}
