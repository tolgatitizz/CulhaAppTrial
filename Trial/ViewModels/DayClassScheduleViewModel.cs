using Trial.APIViewModels;
using Trial.Models;
namespace Trial.ViewModels
{
    public class DayClassScheduleViewModel
    {
        public List<DayClassSchedule>? DayClassSchedules { get; set; }
        public DayClassSchedule? DayClassSchedule { get; set; }
        public DayClassScheduleRequestModel? DayClassScheduleRequestModel { get; set; }
    }
}
