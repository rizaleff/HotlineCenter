using API.Dtos.WorkOrders;
using API.DTOs.Reports;
using API.Models;
using API.Utilities.Handlers;

namespace Client.Contracts;
public interface IWorkOrderDetailRepository : IRepository<WorkReportDetailDto, Guid>
{


    Task<ResponseOKHandler<WorkReportDetailDto>> GetWorkOrderDetails(Guid Guid);
}
