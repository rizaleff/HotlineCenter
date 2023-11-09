using API.Contracts;
using API.Data;
using API.Dtos.WorkOrders;
using API.DTOs.WorkReports;
using API.Models;

namespace API.Repositories;
public class WorkReportRepository : GeneralRepository<WorkReport>, IWorkReportRepository
{
    public WorkReportRepository(HotlineCenterDbContext context) : base(context) { }

    public IEnumerable<WorkReportDetailDto>? GetDetailWorkReport()
    {
        var result = from workReport in _context.WorkReports
                     join workOrder in _context.WorkOrders
                     on workReport.WorkOrderGuid equals workOrder.Guid
                    select new WorkReportDetailDto
                    {
                        Guid = workReport.Guid,
                        Title = workReport.Title,
                        Description = workReport.Description,
                        ReportGuid = workOrder.ReportGuid,
                        WorkOrderGuid = workReport.WorkOrderGuid,
                        IsFinish = workReport.IsFinish,
                        Note = workReport.Note,
                        Photo = workReport.Photo,
                        CreatedDate = workOrder.CreatedDate
                    };

        return result.ToList();
    }

    public IEnumerable<WorkReport>? GetWorkReportByEmployee(Guid employeeGuid)
    {
        return _context.Set<WorkReport>().Where(r => r.EmployeeGuid == employeeGuid).ToList();
    }
}