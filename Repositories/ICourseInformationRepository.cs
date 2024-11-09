using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICourseInformationRepository
    {
        List<CourseInformation> GetCourseInformations();
        void SaveCourseInformation(CourseInformation r);
        void DeleteCourseInformation(CourseInformation r);
        void UpdateCourseInformation(CourseInformation r);
        CourseInformation GetCourseInformationById(int CourseId);

        int GetNewId();
    }
}
