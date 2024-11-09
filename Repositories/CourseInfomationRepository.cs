using BusinessObjects;
using DataAccessLayer;
using Repositories;

public class CourseInformationRepository : ICourseInformationRepository
{
    private CourseInformationDAO courseInfoDAO = CourseInformationDAO.Instance;

    public List<CourseInformation> GetAll() => courseInfoDAO.GetAll();

    public CourseInformation GetByID(int courseID) => courseInfoDAO.GetByID(courseID);

    public void Add(CourseInformation course) => courseInfoDAO.Add(course);

    public void Update(CourseInformation course) => courseInfoDAO.Update(course);

    public void Delete(int courseID) => courseInfoDAO.Delete(courseID);

    public List<CourseInformation> GetCoursesByType(int courseTypeID)
        => courseInfoDAO.GetAll().Where(c => c.CourseTypeID == courseTypeID).ToList();

    public List<CourseInformation> GetActiveCoursesWithAvailableSlots()
        => courseInfoDAO.GetAll().Where(c => c.CourseStatus == CourseStatus.Active && c.CourseMaxCapacity > GetEnrolledStudentCount(c.CourseID)).ToList();

    public int GetEnrolledStudentCount(int courseID)
    {
        // Implement this method based on your enrollment data
        // For now, return a placeholder value
        return 0;
    }

    public List<CourseInformation> SearchCourses(string searchTerm)
        => courseInfoDAO.GetAll().Where(c =