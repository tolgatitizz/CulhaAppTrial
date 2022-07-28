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
            Academician academician1 = new Academician()
            {
                Title = "Ars.Grv",
                Name = "Tolga",
                LastName = "Titiz",
                Email = "tolgatitiz@bakircay.edu.tr",
                IdentityNo = "3211234554",
                IsAssistant = true,
            };
            Academician academician2 = new Academician()
            {
                Title = "Dr.",
                Name = "Seren",
                LastName = "Akdemir",
                Email = "serenakdemir@bakircay.edu.tr",
                IdentityNo = "4566548778",
                IsAssistant = true,
            };
            Academician academician3 = new Academician()
            {
                Title = "Doç. Dr.",
                Name = "Deniz",
                LastName = "Turan",
                Email = "denizturan@bakircay.edu.tr",
                IdentityNo = "7899876556",
                IsAssistant = false,
            };
            Academician academician4 = new Academician()
            {
                Title = "Dr.",
                Name = "Simge",
                LastName = "Urgen",
                Email = "simgeurgen@bakircay.edu.tr",
                IdentityNo = "1477412552",
                IsAssistant = true,
            };
            Academician academician5 = new Academician()
            {
                Title = "Prof. Dr.",
                Name = "Emre",
                LastName = "Turan",
                Email = "emreturan@bakircay.edu.tr",
                IdentityNo = "3698526545",
                IsAssistant = false,
            };
            modelList.Add(academician1);
            modelList.Add(academician2);
            modelList.Add(academician3);
            modelList.Add(academician4);
            modelList.Add(academician5);
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
