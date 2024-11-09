using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Program
    {
        static void Main(string[] args)
        {
            CourseInformationDAO CourseInformationDAO = new CourseInformationDAO();
            CourseInformationDAO.UpdateCourseInformation(new CourseInformation()
            {
                CourseID = 1,
                CourseNumber = "101",
                CourseDescription = "Single Course with a beautiful view of the city.",
                CourseMaxCapacity = 1,
                CourseStatus = CourseStatus.Deleted,
                CoursePricePerDate = 100.00m,
                CourseTypeID = 1
            });
            foreach (CourseInformation r in CourseInformationDAO.GetCourseInformations())
            {
                Console.WriteLine(r.CourseID + " " + r.CourseStatus);
            }
        }
    }
}
