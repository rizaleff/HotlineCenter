using API.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet("details")]
    public IActionResult GetDetails()
    {
        
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
    public IActionResult Create(CreateEmployeeDto employeeDto)
    {
        
    }


    [HttpPut]
    public IActionResult Update(EmployeeDto employeeDto)
    {
        
    }


    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        
    }
}