namespace BusinessObjects
{
    public class ExamSchedule
    {
        public int ExamID { get; set; }
        public DateTime ExamDate { get; set; }
        public string ExamType { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public string ExamStatus { get; set; }
    }
}