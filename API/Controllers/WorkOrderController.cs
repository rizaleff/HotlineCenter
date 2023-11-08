using API.Contracts;
using API.Dtos.Reports;
using API.Dtos.WorkOrders;
using API.Dtos.WorkReports;
using API.DTOs.Reports;
using API.DTOs.WorkOrders;
using API.Models;
using API.Repositories;
using API.Utilities.Enums;
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


    [HttpGet("Get")]
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


    [HttpGet("details/{guid}")]
    public IActionResult GetDetailByGuid(Guid guid)
    {
        var workOrder = _workOrderRepository.GetByGuid(guid);
        var report = _reportRepository.GetByGuid(workOrder.ReportGuid);

        var result = new WorkOrderDetailDto
        {
            Guid = workOrder.Guid,
            Title = workOrder.Title,
            Description = workOrder.Description,
            ReportGuid = workOrder.ReportGuid,
            Status = workOrder.Status,
            ReportDescription = report.Description,
            ReportPhoto = report.Photo,
            CreatedDate = workOrder.CreatedDate,
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
    }
    [HttpGet("MyWorkOrders/{empGuid}")]
    public IActionResult GetWorkOrderByEmpGuid(Guid empGuid)
    {
        var result = _workOrderRepository.GetWoDetailByEmpGuid(empGuid);
        
        if (result is null)
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });
        }
        return Ok(new ResponseOKHandler<IEnumerable<WorkOrderDetailDto>>(result));
    }


    [HttpGet("details")]
    public IActionResult GetAllWorkOrder()
    {
        var result = _workOrderRepository.GetAllWoDetail();

        if (result is null)
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });
        }
        return Ok(new ResponseOKHandler<IEnumerable<WorkOrderDetailDto>>(result));
    }
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
            var report = new EditStatusReportDto
            {
                Guid = workOrderDto.ReportGuid,
                Note = null,
                Status = StatusLevel.OnProcess
            };

            var reportByGuid = _reportRepository.GetByGuid(workOrderDto.ReportGuid);

            if (reportByGuid is null)
            {

                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }

            Report toUpdate = report;
            toUpdate.EmployeeGuid = reportByGuid.EmployeeGuid;
            toUpdate.Title = reportByGuid.Title;
            toUpdate.Description = reportByGuid.Description;
            toUpdate.EmployeeGuid = reportByGuid.EmployeeGuid;
            toUpdate.Photo = reportByGuid.Photo;
            //toUpdate.PhotoUrl = reportByGuid.PhotoUrl;
            toUpdate.CreatedDate = reportByGuid.CreatedDate;

            _reportRepository.Update(toUpdate);

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


    [HttpPut("UpdateStatus")]
    public IActionResult UpdateStatus(UpdateStatusWorkOrderDto workOrderDto)
    {
        try
        {
           _workOrderRepository.UpdateStatusWorkOrder(workOrderDto);

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