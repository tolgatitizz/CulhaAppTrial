using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Trial.APIViewModels;
using Trial.Models;
using Trial.ViewModels;


namespace Trial.Controllers
{
    public class ClassroomController : Controller
    {
        string Baseurl = "http://10.35.0.104:3535/";

        [HttpGet]
        public async Task<IActionResult> Index(Classroom classroom)
        {
            if (!ModelState.IsValid)
            {
                return View(classroom);
            }
            List<Classroom>? classroomList = new List<Classroom>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/classroom");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var classroomRes = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    classroomList = JsonConvert.DeserializeObject<List<Classroom>>(classroomRes);
                }
            }
            ClassroomViewModel ClassroomViewModel = new ClassroomViewModel() { Classrooms = classroomList };
            return View();
        }

        [HttpGet]
        public IActionResult AddClassroom()
        { return View(); }

        [HttpPost]
        public async Task<IActionResult> AddClassroom(ClassroomRequestModel classroom)
        {
            if (!ModelState.IsValid)
            {
                return View(classroom);
            }
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource  using HttpClient
                var classroomJson = JsonConvert.SerializeObject(classroom);
                var requestContent = new StringContent(classroomJson, Encoding.UTF8, "application/json");
                //Checking the response is successful or not which is sent using HttpClient
                var response = await client.PostAsync("api/classroom", requestContent);
                response.EnsureSuccessStatusCode();
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAcademician(Classroom classroom)
        {
            return View();
        }
        public IActionResult EditClassroom(Classroom classroom)
        {
            return View();
        }

    }
}


