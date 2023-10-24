using API.Models;
using API.Utilities.Enums;

namespace API.Dtos.Employees;
public class CreateEmployeeDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderLevel Gender { get; set; } 
    public DateTime Hiring {  get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Guid DivisionGuid { get; set; }

    public static implicit operator Employee(CreateEmployeeDto createEmployeeDto)
    {
        return new Employee
        {
            FirstName = createEmployeeDto.FirstName,
            LastName = createEmployeeDto.LastName,
            BirthDate = createEmployeeDto.BirthDate,
            Gender = createEmployeeDto.Gender,
            HiringDate = createEmployeeDto.Hiring,
            Email = createEmployeeDto.Email,
            PhoneNumber = createEmployeeDto.PhoneNumber,
            DivisionGuid = createEmployeeDto.DivisionGuid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }
}
