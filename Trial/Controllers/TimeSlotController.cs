using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Trial.APIViewModels;
using Trial.Models;
using Trial.ViewModels;

namespace Trial.Controllers
{
    public class TimeSlotController : Controller
    {
        string Baseurl = "http://10.35.0.104:3535/";
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
        public async Task<IActionResult> Select(Academician academician)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index","Academician");
            }
            List<TimeSlot>? timeSlots = new List<TimeSlot>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/timeslot");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var timeSlotRes = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    timeSlots = JsonConvert.DeserializeObject<List<TimeSlot>>(timeSlotRes);
                }
            }
            TimeSlotViewModel timeSlotViewModel = new TimeSlotViewModel() { Academician = academician , TimeSlots = timeSlots , rowCount =5, columnCount = 10 };
            return View(timeSlotViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Select(String academicianId , String slotResult ="" , String description ="ee")
        {
            List<Academician_ConstraintsRequestModel> academicianConstraints = new List<Academician_ConstraintsRequestModel>();
            string[] slotList = new string[0];
            if (slotResult != null)
            {
               slotList = slotResult.Split(" ");
            }
            else
            {
                return RedirectToAction("Index","Academician");
            }

            if(description == null) { description = "Açıklamasız"; }

            List<int> slotListInt = new List<int>();
            int academicianIdInt = 0;
            int.TryParse(academicianId, out academicianIdInt);
            
            for (int i = 0; i < slotList.Length; i++)
            {
                int chk=0;
                int.TryParse(slotList[i], out chk);
                slotListInt.Add(chk);
            }
            for (int i = 0; i < slotList.Length; i++)
            {
                academicianConstraints.Add(new Academician_ConstraintsRequestModel() { AcademicianId = academicianIdInt , Description = description, TimeSlotId = slotListInt.ElementAt(i)});
            }

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource  using HttpClient
                /*foreach (var item in academicianConstraints)
                {
                    var academicianJson = JsonConvert.SerializeObject(item);
                    var requestContent = new StringContent(academicianJson, System.Text.Encoding.UTF8, "application/json");
                    //Checking the response is successful or not which is sent using HttpClient
                    var response = await client.PostAsync("api/academicianconstraint", requestContent);
                    response.EnsureSuccessStatusCode();
                }*/
                var academicianJson = JsonConvert.SerializeObject(academicianConstraints);
                var requestContent = new StringContent(academicianJson, System.Text.Encoding.UTF8, "application/json");
                //Checking the response is successful or not which is sent using HttpClient
                var response = await client.PostAsync("api/academician_constraint", requestContent);
                response.EnsureSuccessStatusCode();
            }
            TimeSlotViewModel viewModel = new TimeSlotViewModel();    

            return RedirectToAction("Index", "TimeSlot" , viewModel);
        }
    }
}
