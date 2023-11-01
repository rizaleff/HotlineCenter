using API.DTOs.Employees;
using API.Models;
using Client.Contracts;

namespace Client.Repositories;
public class CsEmployeeRepository : GeneralRepository<CsEmployeeDto, Guid>, ICsEmployeeRepository
{
    public CsEmployeeRepository(string request = "Employee/Cs/") : base(request)
    {

    }
}
