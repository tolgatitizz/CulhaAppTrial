using Trial.APIViewModels;
using Trial.Models;

namespace Trial.ViewModels
{
    public class AcademicianViewModel
    {
        public List<Academician>? Academicians { get; set; }
        public Academician? Academician { get; set; }
        public AcademicianRequestModel? AcademicianRequestModel { get; set; }
        public List<CourseOffered>? CourseOffereds { get; set; }
        public List<Academician_Constraint>? Academician_Constraints { get; set; }
        public int rowCount, columnCount;
        public List<TimeSlot>? TimeSlots { get; set; }
        public List<EducationArea>? EducatianAreaList { get; set; }
        public List<AcademicianClassSchedule>? AcademicianClassScheduleList { get; set; }
    }
}
