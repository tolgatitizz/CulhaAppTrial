using Microsoft.AspNetCore.Mvc;

namespace Trial.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
