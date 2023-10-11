using Microsoft.AspNetCore.Mvc;

namespace Health_Insurance.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
