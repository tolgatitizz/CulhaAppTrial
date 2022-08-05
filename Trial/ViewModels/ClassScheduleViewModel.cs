using Trial.APIViewModels;
using Trial.Models;
namespace Trial.ViewModels
{
    public class ClassScheduleViewModel
    {
        public List<ClassSchedule>? ClassSchedules { get; set; }
        public ClassSchedule? ClassSchedule { get; set; }
        public ClassScheduleRequestModel? ClassScheduleRequestModel { get; set; }
    }
}
