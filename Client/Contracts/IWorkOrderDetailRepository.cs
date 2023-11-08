using API.Dtos.Tasks;
using API.DTOs.Reports;
using API.Models;
using API.Utilities.Handlers;

namespace Client.Contracts;
public interface IWorkOrderDetailRepository : IRepository<WorkOrderDetailDto, Guid>
{


    Task<ResponseOKHandler<WorkOrderDetailDto>> GetWorkOrderDetails(Guid Guid);
}
