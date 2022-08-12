namespace Trial.Models
{
    public class CourseOffered
    {
        public int Id { get; set; }
        public string Term { get; set; }
        public int COYear { get; set; }
        public char Section { get; set; }
        public Boolean IsOnline { get; set; }
        public int StudentCount { get; set; }
        public Boolean IsAssigned { get; set; }
        public int SemesterCount { get; set; }
        public String CourseCode { get; set; }
        public String DepartmentCode { get; set; }
        public int AcademicianId { get; set; }
    }
}
