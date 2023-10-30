using API.Dtos.Reports;
using API.Models;

namespace API.Contracts;
public interface IReportRepository : IGeneralRepository<Report>
{
    IEnumerable<Report>? GetReportByEmployee(Guid employeeGuid);
}
