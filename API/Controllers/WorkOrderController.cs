using API.Contracts;
using API.Dtos.Reports;
using API.Dtos.Tasks;
using API.Dtos.WorkReports;
using API.DTOs.Reports;
using API.Models;
using API.Repositories;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkOrderController : ControllerBase
{
    private readonly IWorkOrderRepository _workOrderRepository;
    private readonly IReportRepository _reportRepository;

    public WorkOrderController(IWorkOrderRepository workOrderRepository, IReportRepository reportRepository)
    {
        _workOrderRepository = workOrderRepository;
        _reportRepository = reportRepository;

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

    /*[HttpGet("{guid}")]
    public IActionResult GetDetailByGuid(Guid guid)
    {
        var workOrder = _workOrderRepository.GetByGuid(guid);
        var report = _reportRepository.GetByGuid(workOrder.ReportGuid);

        var result = new WorkOrderDetailDto
        {
            Guid = workOrder.Guid,
            Title = workOrder.Title,
            Description = workOrder.Description,
            Status = report.Status,
            CreatedDate = report.CreatedDate,
            ModifiedDate = report.ModifiedDate,
            ReportPhoto = report.Photo,
            Note = report.Note,
            EmployeePhoto = report.Photo
        };
        if (result is null)
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });
        }
        return Ok(new ResponseOKHandler<WorkOrderDetailDto>(result));
    }*/

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var result = _workOrderRepository.GetByGuid(guid);
        if (result is null)
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });
        }
        return Ok(new ResponseOKHandler<WorkOrderDto>((WorkOrderDto)result));
    }

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

    [HttpGet("myWorkOrder/{employeeGuid}")]
    public IActionResult GetByEmployeeGuid(Guid employeeGuid)
    {
        var result = _workOrderRepository.GetWorkOrderByEmployee(employeeGuid);

        if (result is null)
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
}