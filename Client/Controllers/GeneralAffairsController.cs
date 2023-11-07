using API.DTOs.Employees;
using API.DTOs.Reports;
using Client.Contracts;
using Client.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;
[Authorize(Roles = "GA")]
public class GeneralAffairsController : Controller
{
    private readonly IDetailReportRepository _detailReportepository;
    private readonly ICsEmployeeRepository _csEmployeeRepository;

    public GeneralAffairsController(IDetailReportRepository detailReportepository, ICsEmployeeRepository csEmployeeRepository)
    {
        _detailReportepository = detailReportepository;
        _csEmployeeRepository = csEmployeeRepository;
    }
    public async Task<IActionResult> Index()
    {
        var result = await _detailReportepository.Get();
        var listReport = new List<ReportDetailDto>();
        listReport = result.Data.ToList();

        //CS
        var cs = await _csEmployeeRepository.Get();
        ViewBag.ListCs = cs.Data.ToList();
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

