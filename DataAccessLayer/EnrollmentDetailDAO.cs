using BusinessObjects;

namespace DataAccessLayer
{
    public class EnrollmentDetailDAO : SingletonBase<EnrollmentDetailDAO>
    {
        private List<EnrollmentDetail> EnrollmentDetails; // In-memory collection to store Enrollment details

        public EnrollmentDetailDAO()
        {
            EnrollmentDetails = new List<EnrollmentDetail>();

        }


        public List<EnrollmentDetail> GetAllEnrollmentDetails()
        {
            return EnrollmentDetails;
        }

        public EnrollmentDetail GetEnrollmentDetail(int EnrollmentReservationId)
        {
            return EnrollmentDetails.FirstOrDefault(x => x.EnrollmentReservationID == EnrollmentReservationId);
        }

        public void AddEnrollmentDetail(EnrollmentDetail EnrollmentDetail)
        {
            EnrollmentDetails.Add(EnrollmentDetail);
        }

        public void UpdateEnrollmentDetail(EnrollmentDetail updatedEnrollmentDetail)
        {
            EnrollmentDetail existingEnrollmentDetail = EnrollmentDetails.FirstOrDefault(b => b.EnrollmentReservationID == updatedEnrollmentDetail.EnrollmentReservationID && b.CourseID == updatedEnrollmentDetail.CourseID);
            if (existingEnrollmentDetail != null)
            {
                existingEnrollmentDetail.EndDate = updatedEnrollmentDetail.EndDate;
                existingEnrollmentDetail.ActualPrice = updatedEnrollmentDetail.ActualPrice;
            }

        }


        public void DeleteEnrollmentDetail(int EnrollmentReservationId, int CourseId)
        {

            EnrollmentDetail EnrollmentDetailToRemove = EnrollmentDetails.FirstOrDefault(b => b.EnrollmentReservationID == EnrollmentReservationId && b.CourseID == CourseId);
            if (EnrollmentDetailToRemove != null)
            {
                EnrollmentDetails.Remove(EnrollmentDetailToRemove);
            }
        }

       
        public List<CourseInformation> GetAvailableCourses()
        {
            var listIds = EnrollmentDetails.Where(x => x.EnrollmentReservation.EnrollmentStatus != EnrollmentStatus.Pending).Select(x => x.CourseID).ToList();
            var listAllCourse = CourseInformationDAO.Instance.GetCourseInformations();
            var listNotConfirmedCourses = listAllCourse
                .Where(Course => listIds.Contains(Course.CourseID))
                .ToList();
            return listNotConfirmedCourses;
        }

        public List<EnrollmentDetail> GetEnrollmentDetails(int userId)
        {
            var listEnrollmentDetail = EnrollmentDetails.Where(x => x.EnrollmentReservation.StudentID == userId).ToList();
            return listEnrollmentDetail;
        }
    }
}

