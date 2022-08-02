namespace Trial.APIViewModels
{
    public class ClassroomRequestModel
    {
        public int? ClassCapacity { get; set; }
        public int? ExamCapacity { get; set; }
        public string? ClassroomCode { get; set; }
        public Boolean IsEnabled { get; set; }
        public string? Building { get; set; }
        public string? Type { get; set; }
    }
}
