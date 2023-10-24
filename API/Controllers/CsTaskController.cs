using API.Contracts;
using API.Dtos.CsTasks;
using API.Models;
using API.Repositories;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        var result = _csTaskRepository.GetAll();

        if (!result.Any())
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });
        }

        var data = result.Select(x => (CsTaskDto)x);

        return Ok(new ResponseOKHandler<IEnumerable<CsTaskDto>>(data));
    }


    //[HttpGet("{guid}")]
    //public IActionResult GetByGuid(Guid guid)
    //{
       
    //}


    [HttpPost]
    public IActionResult Create(CreateCsTaskDto csTaskDto)
    {
        try
        {
            var result = _csTaskRepository.Create(csTaskDto);

            return Ok(new ResponseOKHandler<CsTaskDto>((CsTaskDto)result));
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
    public IActionResult Update(CsTaskDto csTaskDto)
    {
        try
        {
            var entity = _csTaskRepository.GetByGuid(csTaskDto.Guid);

            if (entity is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id Not Found"
                });
            }

            CsTask toUpdate = csTaskDto;
            toUpdate.CreatedDate = entity.CreatedDate;

            _csTaskRepository.Update(toUpdate);

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
            var entity = _csTaskRepository.GetByGuid(guid);

            if (entity is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id Not Found"
                });
            }

            _csTaskRepository.Delete(entity);

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