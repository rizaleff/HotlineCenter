using API.Dtos.WorkOrders;
using API.DTOs.WorkOrders;
using API.Models;
using WorkOrder = API.Models.WorkOrder;

namespace API.Contracts;
public interface IWorkOrderRepository : IGeneralRepository<WorkOrder>
{
    IEnumerable<WorkOrder>? GetWorkOrderByEmployee(Guid employeeGuid);
    IEnumerable<WorkReportDetailDto>? GetWoDetailByEmpGuid(Guid employeeGuid);
    IEnumerable<WorkReportDetailDto>? GetAllWoDetail();

    bool UpdateStatusWorkOrder(UpdateStatusWorkOrderDto workOrderDto);
}
