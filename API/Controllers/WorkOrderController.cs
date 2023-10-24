using API.Contracts;
using API.Dtos.Tasks;
using API.Models;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkOrderController : ControllerBase
{
    private readonly IWorkOrderRepository _workOrderRepository;

    public WorkOrderController(IWorkOrderRepository workOrderRepository)
    {
        _workOrderRepository = workOrderRepository;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _workOrderRepository.GetAll();

        if (!result.Any())
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });
        }

        var data = result.Select(x => (WorkOrderDto)x);

        return Ok(new ResponseOKHandler<IEnumerable<WorkOrderDto>>(data));
    }


    //[HttpGet("{guid}")]
    //public IActionResult GetByGuid(Guid guid)
    //{
       
    //}


    [HttpPost]
    public IActionResult Create(CreateWorkOrderDto workOrderDto)
    {
        try
        {
            var result = _workOrderRepository.Create(workOrderDto);

            return Ok(new ResponseOKHandler<WorkOrderDto>((WorkOrderDto)result));
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
    public IActionResult Update(WorkOrderDto workOrderDto)
    {
        try
        {
            var entity = _workOrderRepository.GetByGuid(workOrderDto.Guid);

            if (entity is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id Not Found"
                });
            }

            WorkOrder toUpdate = workOrderDto;
            toUpdate.CreatedDate = entity.CreatedDate;

            _workOrderRepository.Update(toUpdate);

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
            var entity = _workOrderRepository.GetByGuid(guid);

            if (entity is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id Not Found"
                });
            }

            _workOrderRepository.Delete(entity);

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