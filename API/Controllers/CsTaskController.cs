using API.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CsTaskController : ControllerBase
{
    private readonly ICsTaskRepository _csTaskRepository;

    public CsTaskController(ICsTaskRepository csTaskRepository)
    {
        _csTaskRepository = csTaskRepository;
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
    public IActionResult Create(CreateCsTaskDto csTaskDto)
    {
        
    }


    [HttpPut]
    public IActionResult Update(CsTaskDto csTaskDto)
    {
        
    }


    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        
    }
}