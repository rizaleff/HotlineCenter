using API.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountRoleController : ControllerBase
{
    private readonly IAccountRoleRepository _accountRoleRepository;

    public AccountRoleController(IAccountRoleRepository accountRoleRepository)
    {
        _accountRoleRepository = accountRoleRepository;
    }


    [HttpGet]
    public IActionResult GetAll()
    {

    }


    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {

    }


    [HttpPost]
    public IActionResult Create(CreateAccountRoleDto accountRoleDto)
    {

    }


    [HttpPut]
    public IActionResult Update(AccountRoleDto accountRoleDto)
    {

    }


    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {

    }
}