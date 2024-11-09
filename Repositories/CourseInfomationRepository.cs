using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CourseInfomationRepository : ICourseInformationRepository
    {
        public void DeleteCourseInformation(CourseInformation r)
        {
            CourseInformationDAO.Instance.DeleteCourseInformation(r);
        }

        public int GetNewId()
        {
            return CourseInformationDAO.Instance.GetNewId();
        }

        public CourseInformation GetCourseInformationById(int CourseId)
        {
            return CourseInformationDAO.Instance.GetCourseInformationById(CourseId);
        }

        public List<CourseInformation> GetCourseInformations()
        {
            return CourseInformationDAO.Instance.GetCourseInformations();
        }

        public void SaveCourseInformation(CourseInformation r)
        {
            CourseInformationDAO.Instance.SaveCourseInformation(r);
        }

        public void UpdateCourseInformation(CourseInformation r)
        {
            CourseInformationDAO.Instance.UpdateCourseInformation(r);
        }
    }
}
