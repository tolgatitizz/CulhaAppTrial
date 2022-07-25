using Microsoft.AspNetCore.Mvc;
using Trial.Models;
using Trial.ViewModels;

namespace Trial.Controllers
{
    public class TimeSlotController : Controller
    {
        public IActionResult Index()
        {
            TimeSlotViewModel timeSlotViewModel = new TimeSlotViewModel();
            return View();
        }
        [HttpGet]
        public IActionResult Select()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Select(List<TimeSlot> timeSlot)
        {
            List<TimeSlot> timeSlots = timeSlot;
            return View();
        }
    }
}
