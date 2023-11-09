using API.Dtos.Accounts;
using API.Dtos.Reports;
using API.DTOs.Reports;
using API.Models;
using API.Utilities.Handlers;

namespace Client.Contracts;
public interface IReportRepository : IRepository<ReportDto, Guid>
{
    Task<ResponseOKHandler<IEnumerable<ReportDto>>> GetMyReport(Guid employeeGuid);
    Task<ResponseOKHandler<IEnumerable<TotalReportDto>>> GetTotalReport();


}
