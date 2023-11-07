using API.Dtos.Accounts;
using API.Dtos.WorkOrders;
using API.Models;
using API.Utilities.Handlers;

namespace Client.Contracts;
public interface IWorkOrderRepository : IRepository<WorkOrderDto, Guid>
{
    Task<ResponseOKHandler<IEnumerable<WorkOrderDetailDto>>> GetWorkOrderByEmployeeGuid(Guid employeeGuid);
}
