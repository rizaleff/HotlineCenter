using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Authorize(Roles = "CS")]
    public class ServiceWorkerController : Controller
    {
        public IActionResult Index()
        {
            return View("Dashboard");
        }

        public IActionResult MyWorkReport()
        {
            return View();
        }

    }
}
