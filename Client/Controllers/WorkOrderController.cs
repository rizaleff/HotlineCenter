using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class WorkOrderController : Controller
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

        public IActionResult VerificationWork()
        {
            return View("VerificationWork");
        }
        public IActionResult VerificationProject()
        {
            return View("VerificationProject");
        }
    }
}
