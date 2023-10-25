using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create() 
        {
            return View("Create");
        }

        public IActionResult Details()
        {
            return View("Details");
        }
    }
}
