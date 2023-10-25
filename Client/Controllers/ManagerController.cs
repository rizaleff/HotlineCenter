using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class ManagerController : Controller
{
    public IActionResult Index()
    {
        return View("Dashboard");
    }

    public IActionResult ProjectList()
    {
        return View("ProjectList");
    }
}