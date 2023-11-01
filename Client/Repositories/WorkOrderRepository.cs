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
    public async Task<ResponseOKHandler<IEnumerable<WorkOrderDto>>> GetWorkOrderByEmployeeGuid(Guid employeeGuid)
    {
        ResponseOKHandler<IEnumerable<WorkOrderDto>> entityVM = null;
        string link = request + "myWorkOrder/" + employeeGuid;
        using (var response = await httpClient.GetAsync(request + "myWorkOrder/" + employeeGuid))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOKHandler<IEnumerable<WorkOrderDto>>>(apiResponse);
        }
        return entityVM;
    }

    public async Task<ResponseOKHandler<IEnumerable<WorkOrderDto>>> GetWorkOrderDetails(Guid guid)
    {
        ResponseOKHandler<IEnumerable<WorkOrderDto>> entityVM = null;
        string link = request  + guid;
        using (var response = await httpClient.GetAsync(request + guid))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOKHandler<IEnumerable<WorkOrderDto>>>(apiResponse);
        }
        return entityVM;
    }

}
