using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICourseTypeRepository
    {
        List<CourseType> GetCourseTypes();
        CourseType GetCourseTypeById(int id);
    }
}
