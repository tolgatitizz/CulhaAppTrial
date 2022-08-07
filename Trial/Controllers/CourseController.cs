using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Trial.APIViewModels;
using Trial.Models;
using Trial.ViewModels;


namespace Trial.Controllers
{
    public class CourseController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CourseOffer()
        {

            return View();
        }
    }
}


