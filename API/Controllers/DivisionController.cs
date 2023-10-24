using API.Contracts;
using API.Dtos.CsTasks;
using API.Dtos.Divisions;
using API.Models;
using API.Repositories;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        var result = _divisionRepository.GetAll();

        if (!result.Any())
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });
        }

        var data = result.Select(x => (DivisionDto)x);

        return Ok(new ResponseOKHandler<IEnumerable<DivisionDto>>(data));
    }


    //[HttpGet("{guid}")]
    //public IActionResult GetByGuid(Guid guid)
    //{
       
    //}


    [HttpPost]
    public IActionResult Create(CreateDivisionDto divisionDto)
    {
        try
        {
            var result = _divisionRepository.Create(divisionDto);

            return Ok(new ResponseOKHandler<DivisionDto>((DivisionDto)result));
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
    public IActionResult Update(DivisionDto divisionDto)
    {
        try
        {
            var entity = _divisionRepository.GetByGuid(divisionDto.Guid);

            if (entity is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id Not Found"
                });
            }

            Division toUpdate = divisionDto;
            toUpdate.CreatedDate = entity.CreatedDate;

            _divisionRepository.Update(toUpdate);

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
            var entity = _divisionRepository.GetByGuid(guid);

            if (entity is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id Not Found"
                });
            }

            _divisionRepository.Delete(entity);

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