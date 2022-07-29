using Microsoft.AspNetCore.Mvc;

namespace Trial.Controllers
{
    public class ClassroomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
