using API.Dtos.WorkOrders;
using API.DTOs.WorkOrders;
using API.Models;
using API.Utilities.Handlers;
using Client.Contracts;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace Client.Repositories;
public class WorkOrderRepository : GeneralRepository<WorkOrderDto, Guid>, IWorkOrderRepository
{
    public WorkOrderRepository(string request = "WorkOrder/") : base(request)
    {

    }
    public async Task<ResponseOKHandler<IEnumerable<WorkReportDetailDto>>> GetWorkOrderByEmployeeGuid(Guid employeeGuid)
    {
        ResponseOKHandler<IEnumerable<WorkReportDetailDto>> entityVM = null;
        string link = request + "myWorkOrder/" + employeeGuid;
        using (var response = await httpClient.GetAsync(request + "MyWorkOrders/" + employeeGuid))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOKHandler<IEnumerable<WorkReportDetailDto>>>(apiResponse);
        }
        return entityVM;
    }

    public async Task<ResponseOKHandler<UpdateStatusWorkOrderDto>> UpdateStatus(UpdateStatusWorkOrderDto upateWorkOrderDto)
    {
        ResponseOKHandler<UpdateStatusWorkOrderDto> entityVM = null;
        StringContent content = new StringContent(JsonConvert.SerializeObject(upateWorkOrderDto), Encoding.UTF8, "application/json");
        using (var response = httpClient.PutAsync(request + "UpdateStatus/", content).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOKHandler<UpdateStatusWorkOrderDto>>(apiResponse);
        }
        return entityVM;
    }


}
