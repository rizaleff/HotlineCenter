using API.Dtos.Tasks;
using API.Models;
using API.Utilities.Handlers;
using Client.Contracts;
using Newtonsoft.Json;

namespace Client.Repositories;
public class WorkOrderRepository : GeneralRepository<WorkOrderDto, Guid>, IWorkOrderRepository
{
    public WorkOrderRepository(string request = "WorkOrder/") : base(request)
    {

    }
    public async Task<ResponseOKHandler<IEnumerable<WorkOrderDetailDto>>> GetWorkOrderByEmployeeGuid(Guid employeeGuid)
    {
        ResponseOKHandler<IEnumerable<WorkOrderDetailDto>> entityVM = null;
        string link = request + "myWorkOrder/" + employeeGuid;
        using (var response = await httpClient.GetAsync(request + "MyWorkOrders/" + employeeGuid))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOKHandler<IEnumerable<WorkOrderDetailDto>>>(apiResponse);
        }
        return entityVM;
    }

    

}
