using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EnrollmentDetailRepository : IEnrollmentDetailRepository
    {
        public void AddEnrollmentDetail(EnrollmentDetail EnrollmentDetail)
        {
            EnrollmentDetailDAO.Instance.AddEnrollmentDetail(EnrollmentDetail);
        }

        public void DeleteEnrollmentDetail(int EnrollmentReservationId, int CourseId)
        {
            EnrollmentDetailDAO.Instance.DeleteEnrollmentDetail(EnrollmentReservationId, CourseId);
        }

        public List<EnrollmentDetail> GetAllEnrollmentDetails()
        {
            return EnrollmentDetailDAO.Instance.GetAllEnrollmentDetails();
        }

        public List<CourseInformation> GetAvailableCourses()
        {
            return EnrollmentDetailDAO.Instance.GetAvailableCourses();
        }

        public EnrollmentDetail GetEnrollmentDetail(int EnrollmentReservationId)
        {
            return EnrollmentDetailDAO.Instance.GetEnrollmentDetail(EnrollmentReservationId);
        }

        public List<EnrollmentDetail> GetEnrollmentDetails(int userId)
        {
            return EnrollmentDetailDAO.Instance.GetEnrollmentDetails(userId);
        }

        public void UpdateEnrollmentDetail(EnrollmentDetail updatedEnrollmentDetail)
        {
            EnrollmentDetailDAO.Instance.UpdateEnrollmentDetail(updatedEnrollmentDetail);
        }
    }
}
