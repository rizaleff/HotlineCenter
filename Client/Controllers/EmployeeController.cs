using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View("Dashboard");
        }

        public IActionResult MyReport()
        {
            return View("MyReport");
        }
    }
}
