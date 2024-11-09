namespace BusinessObjects
{

    public class CourseType
    {
        public int CourseTypeID { get; set; }
        public string CourseTypeName { get; set; }
        public string TypeDescription { get; set; }
        public string TypenNote { get; set; }

        public override string ToString()
        {
            return CourseTypeName;
        }
    }


}
