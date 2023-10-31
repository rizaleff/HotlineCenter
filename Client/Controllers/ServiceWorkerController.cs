using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class ServiceWorkerController : Controller
    {
        public IActionResult Index()
        {
            return View("Dashboard");
        }

        
    }
}
