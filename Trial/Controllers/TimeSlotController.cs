using Microsoft.AspNetCore.Mvc;
using Trial.Models;
using Trial.ViewModels;

namespace Trial.Controllers
{
    public class TimeSlotController : Controller
    {
        public IActionResult Index()
        {
            TimeSlotViewModel viewModel = new TimeSlotViewModel();
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Index(TimeSlotViewModel viewModel)
        {

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Select()
        {
            List<Academician> modelList = new List<Academician>();
            TimeSlotViewModel timeSlotViewModel = new TimeSlotViewModel() { academicians = modelList};
            
            return View(timeSlotViewModel);
        }
        [HttpPost]
        public IActionResult Select(String academicianId , String slotResult , String description)
        {
            List<TimeSlot> list = new List<TimeSlot>();
            List<Academician_Constraint> academicianConstraints = new List<Academician_Constraint>();
            string[] slotList = slotResult.Split(" ");
            List<int> slotListInt = new List<int>();
            int academicianIdInt = 0;
            int.TryParse(academicianId, out academicianIdInt);
            slotList.ElementAt(2);
            
            for (int i = 0; i < slotList.Length; i++)
            {
                int chk=0;
                int.TryParse(slotList[i], out chk);
                slotListInt.Add(chk);
            }
            for (int i = 0; i < 50; i++)
            {
                
                int day=0;
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
                if (!slotListInt.Contains(i))
                {
                    TimeSlot timeSlot = new TimeSlot()
                    {
                        Id = i,
                        Day = day,
                        Slot = i,
                        Description = description,
                    };
                    list.Add(timeSlot);
                }  
            }
            for(int i = 0; i < list.Count; i++)
            {
                Academician_Constraint academician_Constraint = new Academician_Constraint() {
                    AcademicianId = academicianIdInt,
                    Description = list[i].Description,
                    TımeSlotId = list[i].Id,
                };
                academicianConstraints.Add(academician_Constraint);
            }
            Console.WriteLine(list);
            TimeSlotViewModel viewModel = new TimeSlotViewModel() {academician_Constraints = academicianConstraints };    

  
            return RedirectToAction("Index", "TimeSlot" , viewModel);
        }
    }
}
