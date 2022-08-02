using Trial.APIViewModels;
using Trial.Models;

namespace Trial.ViewModels
{
    public class AcademicianViewModel
    {
        public List<Academician>? Academicians { get; set; }
        public Academician? Academician { get; set; }
        public AcademicianRequestModel? AcademicianRequestModel { get; set; }
    }
}
