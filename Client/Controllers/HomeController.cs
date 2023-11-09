using API.Dtos.Accounts;
using API.DTOs;
using API.Models;
using Client.Contracts;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        [HttpGet("Logout/")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> Login()
        {
            var userRole = HttpContext.Session.GetString("Role");

            if (string.IsNullOrEmpty(userRole))
            {
                if (ViewData["LoginStatus"] == null)
                {
                    ViewData["LoginStatus"] = "";
                }
                return View();
            }
            switch (userRole)
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
                HttpContext.Session.SetString("Role", role);

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
            }

            else if (result.Status == "BadRequest")
            {
                ModelState.AddModelError(string.Empty, result.Message);
            }
            else if (result.Status == "NotFound")
            {
                ModelState.AddModelError(string.Empty, result.Message);
            }
            ViewData["LoginStatus"] = result.Status;
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterAccountDto register)
        {
            var result = await _accountRepository.Register(register);

            if (result.Status == "OK")
            {
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Registrasi gagal. Silakan coba lagi.");
            }

            return View(register);
        }
    }
}