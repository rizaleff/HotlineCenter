using API.Dtos.Accounts;
using API.DTOs;
using Client.Contracts;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountRepository _accountRepository;

        public HomeController(ILogger<HomeController> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var result = await _accountRepository.Login(login);

            if (result.Status == "OK")
            {

                HttpContext.Session.SetString("JWToken", result.Data.Token);

                var jwtToken = HttpContext.Session.GetString("JWToken");

                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(jwtToken) as JwtSecurityToken;

                // Baca payload dari token
                var guid = jsonToken.Claims.First(claim => claim.Type == "Guid").Value;
                var email = jsonToken.Claims.First(claim => claim.Type == "Email").Value;
                var fullName = jsonToken.Claims.First(claim => claim.Type == "FullName").Value;
                var profilePhoto = jsonToken.Claims.First(claim => claim.Type == "ProfilePhoto").Value;
                var role = jsonToken.Claims.First(claim => claim.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;
                HttpContext.Session.SetString("FullName", fullName);
                HttpContext.Session.SetString("Guid", guid);
                HttpContext.Session.SetString("Email", email);

                switch (role)
                {
                    case "Employee":
                        return RedirectToAction("Index", "Employee");
                        break;
                    case "CS":
                        return RedirectToAction("Index", "ServiceWorker");
                        break;
                    case "GA":
                        return RedirectToAction("Index", "GeneralAffairs");
                        break;
                    case "Manager":
                        return RedirectToAction("Index", "Manager");
                        break;
                    default:
                        return RedirectToAction("Index");
                        break;

                }

                if (profilePhoto != null) { }
            }
            return View("Login");
        }
    }
}