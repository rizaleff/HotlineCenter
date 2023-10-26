using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class ProjectController : Controller
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

        public IActionResult Edit()
        {
            return View("Edit");
        }

        
        public IActionResult VerificationProject()
        {
            return View("VerificationProject");
        }
    }
}
