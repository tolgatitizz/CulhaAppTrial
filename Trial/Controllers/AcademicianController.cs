using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Trial.APIViewModels;
using Trial.Models;
using Trial.ViewModels;


namespace Trial.Controllers
{
    public class AcademicianController : Controller
    {
        string Baseurl = "http://10.35.0.104:3535/";

        [HttpGet]
        public async Task<IActionResult> Index(Academician academician)
        {
            if (!ModelState.IsValid)
            {
                return View(academician);
            }
            List<Academician>? academicianList = new List<Academician>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/academician");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var academicianRes = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    academicianList = JsonConvert.DeserializeObject<List<Academician>>(academicianRes);
                }
            }
            AcademicianViewModel academicianViewModel = new AcademicianViewModel() { Academicians = academicianList };
            return View(academicianViewModel);
        }

        [HttpGet]
        public IActionResult AddAcademician() 
        { return View(); }

        [HttpPost]
        public async Task<IActionResult> AddAcademician(AcademicianRequestModel academician) 
        { 
            if (!ModelState.IsValid)
            {
                return View(academician);
            }
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource  using HttpClient
                var academicianJson = JsonConvert.SerializeObject(academician);
                var requestContent = new StringContent(academicianJson, Encoding.UTF8, "application/json");
                //Checking the response is successful or not which is sent using HttpClient
                var response = await client.PostAsync("api/academician", requestContent);
                response.EnsureSuccessStatusCode();
            }
                return RedirectToAction("Index"); 
        }

        public IActionResult DeleteAcademician(Academician academician)
        {
            return View();
        }
        public IActionResult EditAcademician(Academician academician)
        {
            return View();
        }

    }
}
