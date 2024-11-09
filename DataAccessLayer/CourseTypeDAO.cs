using BusinessObjects;

namespace DataAccessLayer
{
    public class CourseTypeDAO : SingletonBase<CourseTypeDAO>
    {
        public List<CourseType> GetCourseTypes()
        {
            var list = new List<CourseType>()
            {
            new CourseType
            {
                CourseTypeID = 1,
                CourseTypeName = "Standard Course",
                TypeDescription = "Basic Course with essential amenities.",
                TypenNote = "No special notes."
            },
            new CourseType
            {
                CourseTypeID = 2,
                CourseTypeName = "Deluxe Course",
                TypeDescription = "Luxurious Course with additional amenities.",
                TypenNote = "Includes a mini-bar and city view."
            },
            new CourseType
            {
                CourseTypeID = 3,
                CourseTypeName = "Suite",
                TypeDescription = "Large and luxurious suite.",
                TypenNote = "Includes a separate living area and jacuzzi."
            },
             new CourseType
            {
                CourseTypeID = 4,
                CourseTypeName = "Family Course",
                TypeDescription = "Spacious Course suitable for families.",
                TypenNote = "Equipped with bunk beds and children's play area."
            },
            new CourseType
            {
                CourseTypeID = 5,
                CourseTypeName = "Ocean View Course",
                TypeDescription = "Course with a view of the ocean.",
                TypenNote = "Perfect for guests looking for a scenic view."
            }
            };
            return list;
        }

        public CourseType GetCourseTypeById(int id)
        {
            foreach (var CourseType in GetCourseTypes())
            {
                if (CourseType.CourseTypeID == id) return CourseType;
            }
            return null!;
        }
    }
}
