using Microsoft.AspNetCore.Mvc;
using Trial.Models;
using Trial.ViewModels;

namespace Trial.Controllers
{
    public class TimeSlotController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(TimeSlotViewModel btncheck)
        {
            return View(btncheck);
        }
        [HttpGet]
        public IActionResult Select()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Select(TimeSlotViewModel btncheck)
        {
            
            return View(btncheck);
        }
    }
}
