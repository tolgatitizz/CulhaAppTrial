using Trial.APIViewModels;
using Trial.Models;
namespace Trial.ViewModels
{
    public class CampusViewModel
    {
        public List<Campus>? CampusList = new List<Campus>();
        public List<Faculty>? FacultyList = new List<Faculty>();
        public List<Department>? DepartmentList = new List<Department>();
        public List<Department_Courses>? Department_CoursesList = new List<Department_Courses>();
        public List<Academician>? AcademicianList = new List<Academician>();
        public DepartmentRequestModel? DepartmentRequestModel = new DepartmentRequestModel();
    }
}
