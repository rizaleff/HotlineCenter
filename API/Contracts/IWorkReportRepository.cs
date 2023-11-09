using API.DTOs.WorkReports;
using API.Models;

namespace API.Contracts;
public interface IWorkReportRepository : IGeneralRepository<WorkReport>
{
    IEnumerable<WorkReport>? GetWorkReportByEmployee(Guid employeeGuid);
    IEnumerable<WorkReportDetailDto>? GetDetailWorkReport();


}
