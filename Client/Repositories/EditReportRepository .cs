using API.Dtos.Reports;
using Client.Contracts;

namespace Client.Repositories;
public class EditReportRepository : GeneralRepository<EditStatusReportDto, Guid>, IEditReportRepository
{
    public EditReportRepository(string request = "Report/") : base(request)
    {

    }
}
