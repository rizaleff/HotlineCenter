using API.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly ITaskRepository _projectRepository;

    public ProjectController(ITaskRepository projectRepository)
    {
        _projectRepository = projectRepository;
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
    public IActionResult Create(CreateProjectDto projectDto)
    {
        
    }


    [HttpPut]
    public IActionResult Update(ProjectDto projectDto)
    {
        
    }


    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        
    }
}