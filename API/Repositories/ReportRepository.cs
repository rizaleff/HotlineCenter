using API.Contracts;
using API.Data;
using API.Dtos.Reports;
using API.Models;

namespace API.Repositories;
public class ReportRepository : GeneralRepository<Report>, IReportRepository
{
    public ReportRepository(HotlineCenterDbContext context) : base(context) { }

    public IEnumerable<Report>? GetReportByEmployee(Guid employeeGuid)
    {
        return _context.Set<Report>().Where(r => r.EmployeeGuid == employeeGuid).ToList();
    }
}