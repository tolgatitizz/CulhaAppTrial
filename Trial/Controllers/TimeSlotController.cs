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
            return View( btncheck);
        }
        [HttpGet]
        public IActionResult Select()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Select(String slotResult)
        {
            List<TimeSlot> list = new List<TimeSlot>();
            string[] slotList = slotResult.Split(" ");
            for (int i = 0; i < 50; i++)
            {
                int day = 0;
                if (i >= 40)
                {
                    day = 4;
                }
                else if(i >= 30)
                {
                    day = 3;
                }
                else if (i >= 20)
                {
                    day=2;  
                }
                else if (i >= 10)
                {
                    day=1;
                }
                else if (i < 10)
                {
                    day = 0;
                }
                string btnCheck = "btnCheck" + i;
                TimeSlot timeSlot = new TimeSlot() { 
                    Day = day,
                    Slot =i,
                    Description ="",
                    };
                list.Add(timeSlot);
            }
            return View();
        }
    }
}
