using API.DTOs.Employees;
using API.DTOs.Reports;

namespace Client.Contracts;
public interface ICsEmployeeRepository : IRepository<CsEmployeeDto, Guid>
{

}

