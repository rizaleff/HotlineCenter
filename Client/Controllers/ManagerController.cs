using API.DTOs.Reports;
using Client.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;
[Authorize(Roles = "Manager")]

public class ManagerController : Controller
{
    private readonly IDetailReportRepository _detailReportepository;
    private readonly ICsEmployeeRepository _csEmployeeRepository;

    public ManagerController(IDetailReportRepository detailReportepository, ICsEmployeeRepository csEmployeeRepository)
    {
        _detailReportepository = detailReportepository;
        _csEmployeeRepository = csEmployeeRepository;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _detailReportepository.Get();
        var listReport = new List<ReportDetailDto>();
        listReport = result.Data.ToList();

        var cs = await _csEmployeeRepository.Get();
        ViewBag.ListCs = cs.Data.ToList();

        return View("Dashboard", listReport);
    }

    [Route("Manager/ApproveProject")]
    public IActionResult ApproveProject()
    {
        return View("ApproveProject");
    }
}