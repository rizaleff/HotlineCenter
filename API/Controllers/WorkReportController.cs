using API.Contracts;
using API.Dtos.TaskReports;
using API.Dtos.Tasks;
using API.Dtos.WorkReports;
using API.Models;
using API.Repositories;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkReportController : ControllerBase
{
    private readonly IWorkReportRepository _workReportRepository;

    public WorkReportController(IWorkReportRepository workReportRepository)
    {
        _workReportRepository = workReportRepository;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _workReportRepository.GetAll();

        if (!result.Any())
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });
        }

        var data = result.Select(x => (WorkReportDto)x);

        return Ok(new ResponseOKHandler<IEnumerable<WorkReportDto>>(data));
    }


    //[HttpGet("{guid}")]
    //public IActionResult GetByGuid(Guid guid)
    //{
       
    //}


    [HttpPost]
    public IActionResult Create(CreateWorkReportDto workReportDto)
    {
        try
        {
            var result = _workReportRepository.Create(workReportDto);

            return Ok(new ResponseOKHandler<WorkReportDto>((WorkReportDto)result));
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


    [HttpPut]
    public IActionResult Update(WorkReportDto workReportDto)
    {
        try
        {
            var entity = _workReportRepository.GetByGuid(workReportDto.Guid);

            if (entity is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id Not Found"
                });
            }

            WorkReport toUpdate = workReportDto;
            toUpdate.CreatedDate = entity.CreatedDate;

            _workReportRepository.Update(toUpdate);

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
            var entity = _workReportRepository.GetByGuid(guid);

            if (entity is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id Not Found"
                });
            }

            _workReportRepository.Delete(entity);

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