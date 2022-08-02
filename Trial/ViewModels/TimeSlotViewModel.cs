using Trial.Models;

namespace Trial.ViewModels
{
    public class TimeSlotViewModel
    {
        public List<TimeSlot>? TimeSlots;
        public Academician? Academician;
        public List<Academician_Constraint>? Academician_Constraints;
        public int AcademicianId;
        public int rowCount, columnCount;
    }
}
