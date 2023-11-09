using API.Contracts;
using API.Data;
using API.Dtos.Reports;
using API.Dtos.WorkOrders;
using API.DTOs.Reports;
using API.Models;

namespace API.Repositories;
public class ReportRepository : GeneralRepository<Report>, IReportRepository
{
    public ReportRepository(HotlineCenterDbContext context) : base(context) { }

    public IEnumerable<Report>? GetReportByEmployee(Guid employeeGuid)
    {
        return _context.Set<Report>().Where(r => r.EmployeeGuid == employeeGuid).ToList();
    }

    public IEnumerable<TotalReportDto>? GetTotalReport()
    {

       
        var result = _context.Reports.GroupBy(item => item.Status)
                             .Select(group => new TotalReportDto
                             {
                                 Status = group.Key,
                                 Count = group.Count()
                             });
        return result.ToList();
    }
}