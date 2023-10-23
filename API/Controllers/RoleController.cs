using API.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleRepository _roleRepository;

    public RoleController(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
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
    public IActionResult Create(CreateRoleDto roleDto)
    {
        
    }


    [HttpPut]
    public IActionResult Update(RoleDto roleDto)
    {
        
    }


    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        
    }
}