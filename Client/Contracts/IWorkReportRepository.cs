using API.Dtos.Accounts;
using API.Dtos.WorkReports;
using API.Models;
using API.Utilities.Handlers;

namespace Client.Contracts;
public interface IWorkReportRepository : IRepository<WorkReportDto, Guid>
{
    Task<ResponseOKHandler<IEnumerable<WorkReportDto>>> GetWorkReportByEmployeeGuid(Guid employeeGuid);
}
