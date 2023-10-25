using API.Contracts;
using API.Dtos.Employees;
using API.Dtos.Projects;
using API.Models;
using API.Repositories;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectRepository _projectRepository;

    public ProjectController(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _projectRepository.GetAll();
        if (!result.Any())
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });
        }
        var data = result.Select(x => (ProjectDto)x);
        return Ok(new ResponseOKHandler<IEnumerable<ProjectDto>>(data));
    }


    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var result = _projectRepository.GetByGuid(guid);
        if (result is null)
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });
        }
        return Ok(new ResponseOKHandler<ProjectDto>((ProjectDto)result));
    }


    [HttpPost]
    public IActionResult Create(CreateProjectDto projectDto)
    {
        try
        {
            var result = _projectRepository.Create(projectDto);
            return Ok(new ResponseOKHandler<ProjectDto>((ProjectDto)result));
        }
        catch (ExceptionHandler ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Failed to Create Data",
                Error = ex.Message
            });
        }
    }


    [HttpPut]
    public IActionResult Update(ProjectDto projectDto)
    {
        try
        {
            var projectByGuid = _projectRepository.GetByGuid(projectDto.Guid);

            if (projectByGuid is null)
            {

                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }

            Project toUpdate = projectDto;

            toUpdate.CreatedDate = projectByGuid.CreatedDate;

            _projectRepository.Update(toUpdate);

            return Ok(new ResponseOKHandler<string>("Data Updated"));
        }
        catch (ExceptionHandler ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Failed to create data",
                Error = ex.Message
            });
        }
    }

    [HttpPut("verify")]
    public IActionResult Verify(VerifyProjectDto verifyProjectDto)
    {
        try
        {
            var projectByGuid = _projectRepository.GetByGuid(verifyProjectDto.Guid);

            if (projectByGuid is null)
            {

                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }

            Project toUpdate = verifyProjectDto;

            toUpdate.Title = projectByGuid.Title;
            toUpdate.Description = projectByGuid.Description;
            toUpdate.ReportGuid = projectByGuid.ReportGuid;
            toUpdate.Budget = projectByGuid.Budget;
            toUpdate.CreatedDate = projectByGuid.CreatedDate;

            _projectRepository.Update(toUpdate);

            return Ok(new ResponseOKHandler<string>("Data Updated"));
        }
        catch (ExceptionHandler ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Failed to create data",
                Error = ex.Message
            });
        }
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        try
        {
            var projectByGuid = _projectRepository.GetByGuid(guid);

            if (projectByGuid is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }

            _projectRepository.Delete(projectByGuid);

            return Ok(new ResponseOKHandler<string>("Data Deleted"));
        }
        catch (ExceptionHandler ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Failed to create data",
                Error = ex.Message
            });
        }
    }
}