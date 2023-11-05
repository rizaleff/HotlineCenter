
using API.Dtos.Tasks;
using API.Utilities.Handlers;
using Client.Contracts;
using Newtonsoft.Json;

namespace Client.Repositories;
public class WorkOrderDetailRepository : GeneralRepository<WorkOrderDetailDto, Guid>, IWorkOrderDetailRepository
{
    public WorkOrderDetailRepository(string request = "WorkOrder/details/") : base(request)
    {

    }

    public async Task<ResponseOKHandler<WorkOrderDetailDto>> GetWorkOrderDetails(Guid guid)
    {
        ResponseOKHandler<WorkOrderDetailDto> entityVM = null;
        string link = request + guid;
        using (var response = await httpClient.GetAsync(request + guid))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOKHandler<WorkOrderDetailDto>>(apiResponse);
        }
        return entityVM;
    }
}
