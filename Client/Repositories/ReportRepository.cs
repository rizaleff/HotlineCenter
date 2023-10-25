using API.Dtos.Reports;
using API.Models;
using Client.Contracts;

namespace Client.Repositories;
public class ReportRepository : GeneralRepository<CreateReportDto, Guid>, IReportRepository
{
    public ReportRepository(string request = "Report/") : base(request)
    {

    }
}
