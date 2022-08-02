using Trial.APIViewModels;
using Trial.Models;
namespace Trial.ViewModels
{
    public class ClassroomViewModel
    {
        public List<Classroom>? Classrooms { get; set; }
        public Classroom? Classroom { get; set; }
        public ClassroomRequestModel? ClassroomRequestModel { get; set; }
    }
}
