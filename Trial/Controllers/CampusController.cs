using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Trial.APIViewModels;
using Trial.Models;
using Trial.ViewModels;

namespace Trial.Controllers
{
    public class CampusController : Controller
    {
        string Baseurl = "http://10.35.0.104:3535/";
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Campus> campusList = new List<Campus>();
            List<Faculty> facultyList = new List<Faculty>();
            List<Department> departmentList = new List<Department>();
            List<Department_Courses> department_CoursesList = new List<Department_Courses>();
            List<Academician> academicianList = new List<Academician>();    
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource Campus using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/campus");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var campusRes = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Campus list
                    campusList = JsonConvert.DeserializeObject<List<Campus>>(campusRes);
                }

                client.DefaultRequestHeaders.Clear();
                //Sending request to find web api REST service resource Campus using HttpClient
                HttpResponseMessage ResFaculty = await client.GetAsync("api/Faculty");
                //Checking the response is successful or not which is sent using HttpClient
                if (ResFaculty.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var facultyRes = ResFaculty.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Campus list
                    facultyList = JsonConvert.DeserializeObject<List<Faculty>>(facultyRes);
                }
                client.DefaultRequestHeaders.Clear();
                //Sending request to find web api REST service resource Campus using HttpClient
                HttpResponseMessage ResDepartment = await client.GetAsync("api/Department");
                //Checking the response is successful or not which is sent using HttpClient
                if (ResDepartment.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var departmentRes = ResDepartment.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Campus list
                    departmentList = JsonConvert.DeserializeObject<List<Department>>(departmentRes);
                }
                client.DefaultRequestHeaders.Clear();
                //Sending request to find web api REST service resource Campus using HttpClient
                HttpResponseMessage ResDepartmentCourses = await client.GetAsync("api/Department_Courses");
                //Checking the response is successful or not which is sent using HttpClient
                if (ResDepartmentCourses.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var departmentCoursesRes = ResDepartmentCourses.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Campus list
                    department_CoursesList = JsonConvert.DeserializeObject<List<Department_Courses>>(departmentCoursesRes);
                }
                client.DefaultRequestHeaders.Clear();
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage ResAcademician = await client.GetAsync("api/academician");
                //Checking the response is successful or not which is sent using HttpClient
                if (ResAcademician.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var academicianRes = ResAcademician.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    academicianList = JsonConvert.DeserializeObject<List<Academician>>(academicianRes);
                }
            }
            CampusViewModel campusViewModel = new CampusViewModel() {
                CampusList = campusList,
                FacultyList = facultyList,
                DepartmentList = departmentList,
                Department_CoursesList = department_CoursesList,
                AcademicianList = academicianList
            };
            return View(campusViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentRequestModel department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource  using HttpClient
                var academicianJson = JsonConvert.SerializeObject(department);
                var requestContent = new StringContent(academicianJson, Encoding.UTF8, "application/json");
                //Checking the response is successful or not which is sent using HttpClient
                var response = await client.PostAsync("api/department", requestContent);
                response.EnsureSuccessStatusCode();
                
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource  using HttpClient
                //Checking the response is successful or not which is sent using HttpClient
                var response = await client.DeleteAsync("api/department/2690");
                response.EnsureSuccessStatusCode();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DepartmentSchedule(string DepartmentCode , string Name)
        {
            List<DepartmentClassSchedule>? departmentClassSchedules = new List<DepartmentClassSchedule>();
            List<Department_Courses>? department_courses = new List<Department_Courses>();
            List<TimeSlot>? slotList = new List<TimeSlot>();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource Campus using HttpClient
                
                String resString = "api/department/departmentclassschedule/" + DepartmentCode;
                HttpResponseMessage ResDepartment_Courses = await client.GetAsync(resString);
                //Checking the response is successful or not which is sent using HttpClient
                if (ResDepartment_Courses.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var department_CoursesRes = ResDepartment_Courses.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Campus list
                    departmentClassSchedules = JsonConvert.DeserializeObject<List<DepartmentClassSchedule>>(department_CoursesRes);
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
                ResTimeSlot.EnsureSuccessStatusCode();
            }

            DepartmentViewModel departmentViewModel = new DepartmentViewModel() { DepartmentClassScheduleList = departmentClassSchedules, TimeSlots = slotList, rowCount = 10, columnCount = 5, DepartmentName = Name };
            return View(departmentViewModel);
        }
    }
}
