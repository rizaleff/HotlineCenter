using API.DTOs.Reports;
using Client.Contracts;
using API.Dtos.WorkOrders;
using API.Dtos.WorkReports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;
[Authorize(Roles = "Manager")]

public class ManagerController : Controller
{
    private readonly IDetailReportRepository _detailReportepository;
    private readonly ICsEmployeeRepository _csEmployeeRepository;
    private readonly IWorkOrderDetailRepository _workOrderDetailRepository;
    private readonly IWorkReportRepository _workReportRepository;

    public ManagerController(IDetailReportRepository detailReportepository, ICsEmployeeRepository csEmployeeRepository, IWorkOrderDetailRepository workOrderDetailRepository, IWorkReportRepository workReportRepository)
    {
        _detailReportepository = detailReportepository;
        _csEmployeeRepository = csEmployeeRepository;
        _workOrderDetailRepository = workOrderDetailRepository;
        _workReportRepository = workReportRepository;
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

    public async Task<IActionResult> WorkReport()
    {
        var result = await _workReportRepository.Get();
        var workReport = new List<WorkReportDto>();
        if (result != null)
        {
            workReport = result.Data.ToList();

        }

        return View("WorkReport", workReport);
    }
    public async Task<IActionResult> WorkOrder()
    {
        var result = await _workOrderDetailRepository.Get();
        var listReport = new List<WorkReportDetailDto>();
        if (result != null)
        {
            listReport = result.Data.ToList();

        }

        return View("WorkOrder", listReport);
    }
}