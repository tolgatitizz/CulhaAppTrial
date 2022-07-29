using Microsoft.AspNetCore.Mvc;

namespace Trial.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
