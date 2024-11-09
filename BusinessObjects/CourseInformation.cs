namespace BusinessObjects
{
    public class CourseInformation
    {
        public int CourseID { get; set; }
        public string CourseNumber { get; set; }
        public string CourseDescription { get; set; }
        public int CourseMaxCapacity { get; set; }
        public CourseStatus CourseStatus { get; set; } = CourseStatus.Active;
        public decimal CoursePricePerDate { get; set; }
        public int CourseTypeID { get; set; } // Foreign key to CourseType

        // Navigation property to CourseType
        public CourseType CourseType { get; set; }
    }
}
