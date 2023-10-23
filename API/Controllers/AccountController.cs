using API.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountRepository _accountRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IAccountRoleRepository _accountRoleRepository;
    private readonly IRoleRepository _roleRepository;

    public AccountController(IAccountRepository accountRepository, IEmployeeRepository employeeRepository, IAccountRoleRepository accountRoleRepository, IRoleRepository roleRepository)
    {
        _accountRepository = accountRepository;
        _employeeRepository = employeeRepository;
        _accountRoleRepository = accountRoleRepository;
        _roleRepository = roleRepository;
    }

    // Endpoint untuk login akun.
    [HttpPost("Login")]
    public IActionResult Login(LoginDto loginDto)
    {

    }


    // Endpoint untuk mendaftar akun.
    [HttpPost("Register")]
    public IActionResult Register(RegisterAccountDto registerAccountDto)
    {

    }


    // Endpoint untuk mengatasi lupa password.
    [HttpPut("ForgotPassword")]
    public IActionResult ForgotPassword(string email)
    {

    }


    // Endpoint untuk mengganti password.
    [HttpPut("ChangePassword")]
    public IActionResult ChangePassword(ChangePasswordDto changePasswordDto)
    {

    }


    // Endpoint untuk melihat semua akun.
    [HttpGet]
    public IActionResult GetAll()
    {

    }


    // Endpoint untuk melihat akun berdasarkan GUID.
    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {

    }


    // Endpoint untuk membuat akun baru.
    [HttpPost]
    public IActionResult Create(CreateAccountDto createAccountDto)
    {

    }


    // Endpoint untuk mengupdate data akun.
    [HttpPut]
    public IActionResult Update(AccountDto accountDto)
    {

    }


    // Endpoint untuk menghapus akun berdasarkan GUID.
    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {

    }

}