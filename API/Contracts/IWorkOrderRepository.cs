using API.Dtos.WorkOrders;
using API.DTOs.WorkOrders;
using API.Models;
using WorkOrder = API.Models.WorkOrder;

namespace API.Contracts;
public interface IWorkOrderRepository : IGeneralRepository<WorkOrder>
{
    IEnumerable<WorkOrder>? GetWorkOrderByEmployee(Guid employeeGuid);
    IEnumerable<WorkOrderDetailDto>? GetWoDetailByEmpGuid(Guid employeeGuid);
    IEnumerable<WorkOrderDetailDto>? GetAllWoDetail();

    bool UpdateStatusWorkOrder(UpdateStatusWorkOrderDto workOrderDto);
}
