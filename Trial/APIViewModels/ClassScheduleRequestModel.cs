namespace Trial.APIViewModels
{
    public class ClassScheduleRequestModel
    {
        public int? Id { get; set; }
        public int? ClassScheduleItemNo { get; set; }
        public string? ClassroomCode { get; set; }
        public int? TimeSlotId { get; set; }
        public int? CourseOfferedId { get; set; }
        
    }
}
