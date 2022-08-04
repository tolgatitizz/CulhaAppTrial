namespace Trial.APIViewModels
{
    public class CourseRequestModel
    {
        public string? CourseCode { get; set; }
        public string? CourseName { get; set; }
        public int? Quota { get; set; }
        public Boolean? CourseType { get; set; }
        public int? PracticalHour { get; set; }
        public int? TheoreticalHour { get; set; }
        public float? Credit { get; set; }
        public float? ECTS { get; set; }

    }
}
