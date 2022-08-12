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
            List<CourseOffered>? courseOffereds = new List<CourseOffered>();
            List<Academician_Constraint>? constraintList = new List<Academician_Constraint>(); 
            List<TimeSlot> slotList = new List<TimeSlot>();
            List<EducationArea>? educationAreas = new List<EducationArea>();
            List<AcademicianClassSchedule>? academicianClassSchedules = new List<AcademicianClassSchedule>();
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

                /*client.DefaultRequestHeaders.Clear();
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage ResCourse = await client.GetAsync("api/courseoffered");
                //Checking the response is successful or not which is sent using HttpClient
                if (ResCourse.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var courseRes = ResCourse.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    courseOffereds = JsonConvert.DeserializeObject<List<CourseOffered>>(courseRes);
                }*/
                client.DefaultRequestHeaders.Clear();
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage ResAcCons = await client.GetAsync("api/academicianconstraint");
                //Checking the response is successful or not which is sent using HttpClient
                if (ResAcCons.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var acConsRes = ResAcCons.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    constraintList = JsonConvert.DeserializeObject<List<Academician_Constraint>>(acConsRes);
                }
                client.DefaultRequestHeaders.Clear();
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage ResTimeSlot = await client.GetAsync("api/timeslot");
                //Checking the response is successful or not which is sent using HttpClient
                if (ResTimeSlot.IsSuccessStatusCode)
                {
                    //Storing the response details recieved Sfrom web api
                    var timeSlotRes = ResTimeSlot.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    slotList = JsonConvert.DeserializeObject<List<TimeSlot>>(timeSlotRes);
                }
                client.DefaultRequestHeaders.Clear();
                /*//Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage ResAcClassSchedules = await client.GetAsync("api/EducationArea");
                //Checking the response is successful or not which is sent using HttpClient
                if (ResAcClassSchedules.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var acClassSchedulesRes = ResAcClassSchedules.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    educationAreas = JsonConvert.DeserializeObject<List<EducationArea>>(acClassSchedulesRes);
                }*/
                client.DefaultRequestHeaders.Clear();
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage ResAcSch = await client.GetAsync("api/academician/allacademicianclassschedule");
                //Checking the response is successful or not which is sent using HttpClient
                if (ResAcSch.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var acSchRes = ResAcSch.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    academicianClassSchedules = JsonConvert.DeserializeObject<List<AcademicianClassSchedule>>(acSchRes);
                }
            }
            AcademicianViewModel academicianViewModel = new AcademicianViewModel() {
                Academicians = academicianList,
                CourseOffereds = courseOffereds,
                Academician_Constraints = constraintList,
                columnCount = 5,
                rowCount = 10,
                TimeSlots = slotList,
                EducatianAreaList = educationAreas,
                AcademicianClassScheduleList = academicianClassSchedules
            };
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
