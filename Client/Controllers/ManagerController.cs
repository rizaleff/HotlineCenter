using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View("Dashboard");
        }

        [Route("Manager/ApproveProject")]
        public IActionResult ApproveProject()
        {
            return View("ApproveProject");
        }
    }
}
