using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Trial.APIViewModels;
using Trial.Models;
using Trial.ViewModels;


namespace Trial.Controllers
{
    public class ClassScheduleController : Controller
    {
        string Baseurl = "http://10.35.0.104:3535/";

        [HttpGet]
        public async Task<IActionResult> Index(ClassSchedule classSchedule)
        {
            if (!ModelState.IsValid)
            {
                return View(classSchedule);
            }
            List<ClassSchedule>? classScheduleList = new List<ClassSchedule>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/classSchedule");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var classScheduleRes = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    classScheduleList = JsonConvert.DeserializeObject<List<ClassSchedule>>(classScheduleRes);
                }
            }
            ClassScheduleViewModel classScheduleViewModel = new ClassScheduleViewModel() { ClassSchedules = classScheduleList };
            return View(classScheduleViewModel);
        }

        [HttpGet]
        public IActionResult AddClassSchedule()
        { return View(); }

        [HttpPost]
        public async Task<IActionResult> AddClassSchedule(ClassScheduleRequestModel classSchedule)
        {
            if (!ModelState.IsValid)
            {
                return View(classSchedule);
            }
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource  using HttpClient
                var classScheduleJson = JsonConvert.SerializeObject(classSchedule);
                var requestContent = new StringContent(classScheduleJson, Encoding.UTF8, "application/json");
                //Checking the response is successful or not which is sent using HttpClient
                var response = await client.PostAsync("api/classSchedule", requestContent);
                response.EnsureSuccessStatusCode();
            }
            return RedirectToAction("Index");
        }


    }
}



