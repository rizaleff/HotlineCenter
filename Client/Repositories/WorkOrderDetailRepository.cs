
using API.Dtos.WorkOrders;
using API.Utilities.Handlers;
using Client.Contracts;
using Newtonsoft.Json;

namespace Client.Repositories;
public class WorkOrderDetailRepository : GeneralRepository<WorkReportDetailDto, Guid>, IWorkOrderDetailRepository
{
    public WorkOrderDetailRepository(string request = "WorkOrder/details/") : base(request)
    {

    }

    public async Task<ResponseOKHandler<WorkReportDetailDto>> GetWorkOrderDetails(Guid guid)
    {
        ResponseOKHandler<WorkReportDetailDto> entityVM = null;
        string link = request + guid;
        using (var response = await httpClient.GetAsync(request + guid))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOKHandler<WorkReportDetailDto>>(apiResponse);
        }
        return entityVM;
    }
}
