namespace Trial.Models
{
    public class Academician_Constraint
    {
        public int? Id { get; set; }
        public string? Description { get; set; }
        public int AcademicianId { get; set; }
        public int TımeSlotId { get; set; }
    }
}
