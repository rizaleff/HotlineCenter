using API.Dtos.WorkReports;
using API.Models;
using API.Utilities.Handlers;
using Client.Contracts;
using Newtonsoft.Json;

namespace Client.Repositories;
public class WorkReportRepository : GeneralRepository<WorkReportDto, Guid>, IWorkReportRepository
{
    public WorkReportRepository(string request = "WorkReport/") : base(request)
    {

    }
    public async Task<ResponseOKHandler<IEnumerable<WorkReportDto>>> GetWorkReportByEmployeeGuid(Guid employeeGuid)
    {
        ResponseOKHandler<IEnumerable<WorkReportDto>> entityVM = null;
        string link = request + "myWorkReport/" + employeeGuid;
        using (var response = await httpClient.GetAsync(request + "myWorkReport/" + employeeGuid))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOKHandler<IEnumerable<WorkReportDto>>>(apiResponse);
        }
        return entityVM;
    }

}
