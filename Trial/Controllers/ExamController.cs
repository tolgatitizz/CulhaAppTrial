using Microsoft.AspNetCore.Mvc;

namespace Trial.Controllers
{
    public class ExamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
