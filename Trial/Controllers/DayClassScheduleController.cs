using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Trial.APIViewModels;
using Trial.Models;
using Trial.ViewModels;


namespace Trial.Controllers
{
    public class DayClassScheduleController : Controller
    {
        string Baseurl = "http://10.35.0.104:3535/api/timeslot/dayclassschedule/1";

        [HttpGet]
        public async Task<IActionResult> Index(DayClassSchedule dayClassSchedule)
        {
            if (!ModelState.IsValid)
            {
                return View(dayClassSchedule);
            }
            List<DayClassSchedule>? dayClassScheduleList = new List<DayClassSchedule>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("http://10.35.0.104:3535/api/timeslot/dayclassschedule/1");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var dayClassScheduleRes = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    dayClassScheduleList = JsonConvert.DeserializeObject<List<DayClassSchedule>>(dayClassScheduleRes);
                }
            }
            DayClassScheduleViewModel dayClassScheduleViewModel = new DayClassScheduleViewModel() { DayClassSchedules = dayClassScheduleList };
            return View(dayClassScheduleViewModel);
        }

        [HttpGet]
        public IActionResult AddDayClassSchedule()
        { return View(); }

        [HttpPost]
        public async Task<IActionResult> AddDayClassSchedule(DayClassScheduleRequestModel dayClassSchedule)
        {
            if (!ModelState.IsValid)
            {
                return View(dayClassSchedule);
            }
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource  using HttpClient
                var dayClassScheduleJson = JsonConvert.SerializeObject(dayClassSchedule);
                var requestContent = new StringContent(dayClassScheduleJson, Encoding.UTF8, "application/json");
                //Checking the response is successful or not which is sent using HttpClient
                var response = await client.PostAsync("api/dayClassSchedule", requestContent);
                response.EnsureSuccessStatusCode();
            }
            return RedirectToAction("Index");
        }


    }
}



