using API.Dtos.Reports;
using API.Models;

namespace Client.Contracts
{
    public interface IReportRepository : IRepository<CreateReportDto, Guid>
    {


    }
}
