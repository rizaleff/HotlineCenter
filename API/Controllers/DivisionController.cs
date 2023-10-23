using API.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DivisionController : ControllerBase
{
    private readonly IDivisionRepository _divisionRepository;

    public DivisionController(IDivisionRepository divisionRepository)
    {
        _divisionRepository = divisionRepository;
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
    public IActionResult Create(CreateDivisionDto divisionDto)
    {
        
    }


    [HttpPut]
    public IActionResult Update(DivisionDto divisionDto)
    {
        
    }


    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        
    }
}