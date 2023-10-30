using API.DTOs.Reports;
using API.Models;

namespace Client.Contracts;
public interface IDetailReportRepository : IRepository<ReportDetailDto, Guid>
{


}
