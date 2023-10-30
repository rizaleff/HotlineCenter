using API.Dtos.Reports;
using Client.Contracts;

namespace Client.Repositories;
public class CreateReportRepository : GeneralRepository<CreateReportDto, Guid>, ICreateReportRepository
{
    public CreateReportRepository(string request = "Report/") : base(request)
    {

    }
}
