using API.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskRepository _taskRepository;

    public TaskController(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
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
    public IActionResult Create(CreateTaskDto taskDto)
    {
        
    }


    [HttpPut]
    public IActionResult Update(TaskDto taskDto)
    {
        
    }


    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        
    }
}