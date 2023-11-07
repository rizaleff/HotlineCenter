using API.Dtos.Employees;
using API.Dtos.Reports;
using API.DTOs.Reports;
using Client.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;
[Authorize(Roles = "Employee")]
public class EmployeeController : Controller
{
    private readonly IDetailReportRepository _detailReportepository;
    private readonly IReportRepository _reportepository;
    public EmployeeController(IDetailReportRepository detailReportepository, IReportRepository reportRepository)
    {
        _detailReportepository = detailReportepository;
        _reportepository = reportRepository;
    }
    public async Task<IActionResult> Index()
    {
        var result = await _detailReportepository.Get();
        var listReport = new List<ReportDetailDto>();
        if (result.Data != null)
        {
            listReport = result.Data.ToList();
        }
        return View("Dashboard", listReport);
    }

    public async Task<IActionResult> MyReport(Guid employeeGuid)
    {
        var result = await _reportepository.GetMyReport(employeeGuid);
        var listMyReport = new List<ReportDto>();
        listMyReport = result.Data.ToList();
        return View("MyReport", listMyReport);
    }
}
