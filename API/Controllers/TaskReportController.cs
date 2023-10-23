using API.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskReportController : ControllerBase
{
    private readonly ITaskReportRepository _taskReportRepository;

    public TaskReportController(ITaskReportRepository taskReportRepository)
    {
        _taskReportRepository = taskReportRepository;
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
    public IActionResult Create(CreateTaskReportDto taskReportDto)
    {
        
    }


    [HttpPut]
    public IActionResult Update(TaskReportDto taskReportDto)
    {
        
    }


    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        
    }
}