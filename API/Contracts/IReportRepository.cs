using API.Dtos.Reports;
using API.DTOs.Reports;
using API.Models;

namespace API.Contracts;
public interface IReportRepository : IGeneralRepository<Report>
{
    IEnumerable<Report>? GetReportByEmployee(Guid employeeGuid);

    IEnumerable<TotalReportDto>? GetTotalReport();
}
