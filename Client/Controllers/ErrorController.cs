using Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers;
[Authorize]
public class ErrorController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    [AllowAnonymous]
    [HttpGet("/Unauthorized")]
    public IActionResult Unauthorized()
    {
        return View("401");
    }
    [AllowAnonymous]
    [HttpGet("/NotFound")]
    public IActionResult Notfound()
    {
        return View("404");
    }

    [AllowAnonymous]
    [Route("/Forbidden")]
    public IActionResult Forbidden()
    {
        return View("403");
    }
}