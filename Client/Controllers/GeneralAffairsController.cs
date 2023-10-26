using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class GeneralAffairsController : Controller
    {
        public IActionResult Index()
        {
            return View("Dashboard");
        }

        public IActionResult Projects()
        {
            return View("Projects");
        }
        public IActionResult WorkOrder()
        {
            return View("WorkOrder");
        }
    }
}
