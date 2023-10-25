using API.Models;
using Client.Contracts;

namespace Client.Repositories;
public class ReportRepository : GeneralRepository<Report, Guid>, IReportRepository
{
    public ReportRepository(string request = "Report/") : base(request)
    {

    }
}
