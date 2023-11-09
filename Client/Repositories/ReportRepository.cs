using API.Dtos.Reports;
using API.DTOs.Reports;
using API.Models;
using API.Utilities.Handlers;
using Client.Contracts;
using Newtonsoft.Json;

namespace Client.Repositories;
public class ReportRepository : GeneralRepository<ReportDto, Guid>, IReportRepository
{
    public ReportRepository(string request = "Report/") : base(request)
    {

    }
    public async Task<ResponseOKHandler<IEnumerable<ReportDto>>> GetMyReport(Guid employeeGuid)
    {
        ResponseOKHandler<IEnumerable<ReportDto>> entityVM = null;
        string link = request + "myReport/" + employeeGuid;
        using (var response = await httpClient.GetAsync(request + "myReport/" + employeeGuid))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOKHandler<IEnumerable<ReportDto>>>(apiResponse);
        }
        return entityVM;
    }

    public async Task<ResponseOKHandler<IEnumerable<TotalReportDto>>> GetTotalReport()
    {
        ResponseOKHandler<IEnumerable<TotalReportDto>> entityVM = null;
        using (var response = await httpClient.GetAsync(request + "TotalReport/"))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseOKHandler<IEnumerable<TotalReportDto>>>(apiResponse);
        }
        return entityVM;
    }

}
