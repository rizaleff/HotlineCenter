using API.DTOs.Reports;
using Client.Contracts;

namespace Client.Repositories;
public class DetailReportRepository : GeneralRepository<ReportDetailDto, Guid>, IDetailReportRepository
{
    public DetailReportRepository(string request = "Report/details/") : base(request)
    {

    }
}
