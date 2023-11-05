using API.Dtos.WorkReports;
using Client.Contracts;

namespace Client.Repositories;
public class CreateWorkReportRepository : GeneralRepository<CreateWorkReportDto, Guid>, ICreateWorkReportRepository
{
    public CreateWorkReportRepository(string request = "WorkReport/") : base(request)
    {

    }
}
