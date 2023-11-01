using API.Dtos.Accounts;
using API.Dtos.Tasks;
using API.Models;
using API.Utilities.Handlers;

namespace Client.Contracts;
public interface IWorkOrderRepository : IRepository<WorkOrderDto, Guid>
{
    Task<ResponseOKHandler<IEnumerable<WorkOrderDto>>> GetWorkOrderByEmployeeGuid(Guid employeeGuid);
    Task<ResponseOKHandler<IEnumerable<WorkOrderDto>>> GetWorkOrderDetails(Guid Guid);
}
