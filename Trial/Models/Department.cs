namespace Trial.Models
{
    public class Department
    {
        public string DepartmentCode { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public int? DepartmentChair { get; set; }
        public string? Email { get; set; }

    }
}
