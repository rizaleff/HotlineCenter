using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;
public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(HotlineCenterDbContext context) : base(context) { }
    public string GetLastNik()
    {
        Employee? employee = _context.Employees.OrderByDescending(e => e.Nik).FirstOrDefault();
        return employee?.Nik ?? "";
    }
}