using Microsoft.AspNetCore.Mvc;

namespace Trial.Controllers
{
    public class CampusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
