namespace Trial.Models
{
    public class AcademicianClassSchedule
    {
        public int? AcademicianId { get; set; }
        public int? TimeSlotId { get; set; }
        public string CourseName { get; set; }
        public string ClassroomCode { get; set; }
        public int? SemesterCount { get; set; }
        public string CourseCode { get; set; }
    }
}
