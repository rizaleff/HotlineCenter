using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;
public class WorkReportRepository : GeneralRepository<WorkReport>, IWorkReportRepository
{
    public WorkReportRepository(HotlineCenterDbContext context) : base(context) { }

    public IEnumerable<WorkReport>? GetWorkReportByEmployee(Guid employeeGuid)
    {
        return _context.Set<WorkReport>().Where(r => r.EmployeeGuid == employeeGuid).ToList();
    }
}