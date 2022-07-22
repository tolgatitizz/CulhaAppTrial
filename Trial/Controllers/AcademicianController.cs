using Microsoft.AspNetCore.Mvc;
using Trial.Models;
using Trial.ViewModels;

namespace Trial.Controllers
{
    public class AcademicianController : Controller
    {
        List<Academician> modelList = new List<Academician>();
        Academician academician1 = new Academician()
        {
            Title = "Doç. Dr.",
            Name = "Tolga",
            LastName = "Titiz",
            Email = "tolgatitiz@bakircay.edu.tr",
            IdentityNo = "3211234554",
            IsAssistant = true,
        };
        Academician academician2 = new Academician()
        {
            Title = "Doç. Dr.",
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

        [HttpGet]
        public IActionResult Index()
        {
            
            modelList.Add(academician1);
            modelList.Add(academician2);
            modelList.Add(academician3);
            modelList.Add(academician4);
            modelList.Add(academician5);

            AcademicianViewModel academicianViewModel = new AcademicianViewModel()
            {
                Academicians = modelList,
            };
            return View(academicianViewModel);
        }

        [HttpGet]
        public IActionResult AddAcademician() 
        { return View(); }

        [HttpPost]
        public IActionResult AddAcademician(Academician academician) 
        { 
            if (!ModelState.IsValid)
            {
                return View(academician);
            }

            modelList.Add(academician);

            return RedirectToAction("Index"); 
        }

        public IActionResult DeleteAcademician()
        {
            return View();
        }
        public IActionResult EditAcademician()
        {
            return View();
        }
    }
}
