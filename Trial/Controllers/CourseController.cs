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
        string Baseurl = "http://10.35.0.104:3535/";

        [HttpGet]
        public async Task<IActionResult> Index(Course course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }
            List<Course>? courseList = new List<Course>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/course");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var courseRes = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    courseList = JsonConvert.DeserializeObject<List<Course>>(courseRes);
                }
            }
            CourseViewModel CourseViewModel = new CourseViewModel() { Courses = courseList };
            return View(CourseViewModel);
        }

        [HttpGet]
        public IActionResult AddCourse()
        { return View(); }

        [HttpPost]
        public async Task<IActionResult> AddCourse(CourseRequestModel course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource  using HttpClient
                var courseJson = JsonConvert.SerializeObject(course);
                var requestContent = new StringContent(courseJson, Encoding.UTF8, "application/json");
                //Checking the response is successful or not which is sent using HttpClient
                var response = await client.PostAsync("api/course", requestContent);
                response.EnsureSuccessStatusCode();
            }
            return RedirectToAction("Index");
        }


    }
}


