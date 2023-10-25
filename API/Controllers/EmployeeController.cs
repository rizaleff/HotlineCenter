using API.Contracts;
using API.Dtos.Employees;
using API.Models;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

   /* [HttpGet("details")]
    public IActionResult GetDetails()
    {
        
    }
*/

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _employeeRepository.GetAll();
        if (!result.Any())
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound, 
                Status = HttpStatusCode.NotFound.ToString(), 
                Message = "Data Not Found"
            });
        }
        var data = result.Select(x => (EmployeeDto)x);
        return Ok(new ResponseOKHandler<IEnumerable<EmployeeDto>>(data));
    }


    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var result = _employeeRepository.GetByGuid(guid);
        if (result is null)
        {
            return NotFound(new ResponseErrorHandler
            {
                Code = StatusCodes.Status404NotFound, 
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found" 
            });
        }
        return Ok(new ResponseOKHandler<EmployeeDto>((EmployeeDto)result));
    }


    [HttpPost]
    public IActionResult Create(CreateEmployeeDto employeeDto)
    {
        try
        {
            Employee toCreate = employeeDto;
            toCreate.Nik = GenerateHandler.Nik(_employeeRepository.GetLastNik());
            var result = _employeeRepository.Create(toCreate);
            return Ok(new ResponseOKHandler<EmployeeDto>((EmployeeDto)result));
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
    public IActionResult Update(EmployeeDto employeeDto)
    {
        try
        {
            var employeeByGuid = _employeeRepository.GetByGuid(employeeDto.Guid);

            if (employeeByGuid is null)
            {
               
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound, 
                    Status = HttpStatusCode.NotFound.ToString(), 
                    Message = "Data Not Found"
                });
            }

            Employee toUpdate = employeeDto;
            toUpdate.Nik = employeeByGuid.Nik;

           
            toUpdate.CreatedDate = employeeByGuid.CreatedDate;

            _employeeRepository.Update(toUpdate);

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
            
            var employeeByGuid = _employeeRepository.GetByGuid(guid);

            if (employeeByGuid is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound, 
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }

            _employeeRepository.Delete(employeeByGuid);

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