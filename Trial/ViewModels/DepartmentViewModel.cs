using Trial.Models;

namespace Trial.ViewModels
{
    public class DepartmentViewModel
    {
        public List<DepartmentClassSchedule>? DepartmentClassScheduleList = new List<DepartmentClassSchedule>();
        public List<TimeSlot>? TimeSlots = new List<TimeSlot>();
        public int rowCount = 10;
        public int columnCount = 5;
        public string? DepartmentName;
    }
}
