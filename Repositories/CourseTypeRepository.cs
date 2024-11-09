using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class CourseTypeRepository : ICourseTypeRepository
    {
        public CourseType GetCourseTypeById(int id)
        {
            return CourseTypeDAO.Instance.GetCourseTypeById(id);
        }

        public List<CourseType> GetCourseTypes()
        {
            return CourseTypeDAO.Instance.GetCourseTypes();
        }
    }
}
