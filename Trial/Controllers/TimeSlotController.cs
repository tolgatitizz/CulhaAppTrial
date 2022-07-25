using Microsoft.AspNetCore.Mvc;

namespace Trial.Controllers
{
    public class TimeSlotController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Select()
        {
            return View();
        }
    }
}
