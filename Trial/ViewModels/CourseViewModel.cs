using Trial.APIViewModels;
using Trial.Models;
namespace Trial.ViewModels
{
    public class CourseViewModel
    {
        public List<Course>? Courses { get; set; }
        public Course? Course { get; set; }
        public CourseRequestModel? CourseRequestModel { get; set; }
    }
}
