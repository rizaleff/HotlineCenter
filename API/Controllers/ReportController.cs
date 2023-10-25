﻿using API.Contracts;
using API.Dtos.Projects;
using API.Dtos.Reports;
using API.DTOs.Reports;
using API.Models;
using API.Repositories;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly IReportRepository _reportRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public ReportController(IReportRepository reportRepository, IEmployeeRepository employeeRepository)
    {
        _reportRepository = reportRepository;
        _employeeRepository = employeeRepository;
    }


    [HttpGet]
    public IActionResult GetAllDetail()
    {
        var reports = _reportRepository.GetAll();
        var employees = _employeeRepository.GetAll();

        if (!reports.Any() || !employees.Any())
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });
        }
        var reportDetails = from rep in reports
                            join emp in employees on rep.EmployeeGuid equals emp.Guid
                            select new ReportDetailDto
                            {
                                Guid = rep.Guid,
                                Title = rep.Title,
                                Description = rep.Description,
                                EmployeeFullName = emp.FirstName +" "+emp.LastName,
                                Status = rep.Status,
                                CreatedDate = rep.CreatedDate,
                                ModifiedDate = rep.ModifiedDate,
                                ReportPhotoUrl = rep.PhotoUrl,
                                EmployeePhotoUrl = emp.PhotoUrl
                            };

        return Ok(new ResponseOKHandler<IEnumerable<ReportDetailDto>>(reportDetails));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _reportRepository.GetAll();
        if (!result.Any())
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });
        }
        var data = result.Select(x => (ReportDto)x);
        return Ok(new ResponseOKHandler<IEnumerable<ReportDto>>(data));
    }


    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var result = _reportRepository.GetByGuid(guid);
        if (result is null)
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found"
            });
        }
        return Ok(new ResponseOKHandler<ReportDto>((ReportDto)result));
    }


    [HttpPost]
    public IActionResult Create(CreateReportDto reportDto)
    {
        try
        {
            var result = _reportRepository.Create(reportDto);
            return Ok(new ResponseOKHandler<ReportDto>((ReportDto)result));
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
    public IActionResult Update(ReportDto reportDto)
    {
        try
        {
            var reportByGuid = _reportRepository.GetByGuid(reportDto.Guid);

            if (reportByGuid is null)
            {

                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }

            Report toUpdate = reportDto;

            toUpdate.CreatedDate = reportByGuid.CreatedDate;

            _reportRepository.Update(toUpdate);

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

    [HttpPut]
    public IActionResult UpdateStatus(EditStatusReportDto editStatusReportDto)
    {
        try
        {
            var reportByGuid = _reportRepository.GetByGuid(editStatusReportDto.Guid);

            if (reportByGuid is null)
            {

                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }

            Report toUpdate = editStatusReportDto;
            toUpdate.EmployeeGuid = reportByGuid.EmployeeGuid;
            toUpdate.Title = reportByGuid.Title; 
            toUpdate.Description = reportByGuid.Description;
            toUpdate.PhotoUrl = reportByGuid.PhotoUrl;
            toUpdate.CreatedDate = reportByGuid.CreatedDate;

            _reportRepository.Update(toUpdate);

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
            var reportByGuid = _reportRepository.GetByGuid(guid);

            if (reportByGuid is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }

            _reportRepository.Delete(reportByGuid);

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