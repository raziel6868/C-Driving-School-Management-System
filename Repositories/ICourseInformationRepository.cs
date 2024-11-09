using System.Collections.Generic;
using BusinessObjects;

namespace Repositories
{
    public interface ICourseInformationRepository
    {
        List<CourseInformation> GetAll();
        CourseInformation GetByID(int courseID);
        void Add(CourseInformation course);
        void Update(CourseInformation course);
        void Delete(int courseID);
        List<CourseInformation> GetCoursesByType(int courseTypeID);
        List<CourseInformation> GetActiveCoursesWithAvailableSlots();
        int GetEnrolledStudentCount(int courseID);
        List<CourseInformation> SearchCourses(string searchTerm);
        int GetNewId();
        void SaveCourseInformation(CourseInformation courseInfo);
    }
}