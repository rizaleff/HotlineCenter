using API.DTOs.Reports;
using Client.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;
[Authorize(Roles = "GA")]
public class GeneralAffairsController : Controller
{
    private readonly IDetailReportRepository _detailReportepository;

    public GeneralAffairsController(IDetailReportRepository detailReportepository)
    {
        _detailReportepository = detailReportepository;

    }
    public async Task<IActionResult> Index()
    {
        var result = await _detailReportepository.Get();
        var listReport = new List<ReportDetailDto>();
        listReport = result.Data.ToList();
        return View("Dashboard", listReport);
    }

    public IActionResult Projects()
    {
        return View("Projects");
    }
    public IActionResult WorkOrder()
    {
        return View("WorkOrder");
    }
}

