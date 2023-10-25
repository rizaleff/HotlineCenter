using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;
public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(HotlineCenterDbContext context) : base(context) { }
    public string? GetLastNik()
    {
        return _context.Employees.OrderByDescending(e => e.Nik).Select(e => e.Nik).FirstOrDefault();
    }

    public Employee GetEmail(string email)
    {
        var entity = _context.Set<Employee>().FirstOrDefault(e => e.Email == email);
        _context.ChangeTracker.Clear();
        return entity;
    }
}