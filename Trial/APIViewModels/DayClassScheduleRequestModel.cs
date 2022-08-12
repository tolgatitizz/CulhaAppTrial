namespace Trial.APIViewModels
{
    public class DayClassScheduleRequestModel
    {
       
        public string? ClassroomCode { get; set; }
       
        public string? CourseName { get; set; }
        public int? SemesterCount { get; set; }
        public string? DepartmentName { get; set; }
        public string? AcademicianFullName { get; set; }
        public int? Slot { get; set; }
    }
}
