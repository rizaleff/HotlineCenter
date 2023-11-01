using API.Dtos.Reports;
using API.Dtos.Tasks;
using API.DTOs.Employees;
using API.DTOs.Reports;
using API.DTOs.WorkOrders;
using Client.Contracts;
using Client.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Client.Controllers;
public class WorkOrderController : Controller
{

    private readonly ICsEmployeeRepository _csEmployeeRepository;
    private readonly ICreateWorkOrderRepository _createWorkOrderRepository;


    public WorkOrderController(ICsEmployeeRepository csEmployeeRepository, ICreateWorkOrderRepository createWorkOrderRepository)
    {
        _csEmployeeRepository = csEmployeeRepository;
        _createWorkOrderRepository = createWorkOrderRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    /*    [HttpPost]
        public async Task<IActionResult> ToCreate(CreateWorkOrderDto createWorkOrderDto)
        {

            var result = await _createWorkOrderRepository.Post(createWorkOrderDto);
            if (result.Code == 200)
            {
                return RedirectToAction("Index", "Employee");
            }
            ModelState.AddModelError(string.Empty, result.Message);
            return View();
        }*/

    [HttpPost]
    public async Task<JsonResult> ToCreate(CreateWorkOrderDto createWorkOrderDto)
    {

        var result = await _createWorkOrderRepository.Post(createWorkOrderDto);
        return Json(result.Data);
    }
    public async Task<IActionResult> Create(Guid reportGuid)
    {
        var result = await _csEmployeeRepository.Get();
        var listCs = new List<CsEmployeeDto>();
        ViewBag.ReportGuid = reportGuid;
        ViewBag.ListCs = result.Data.ToList();

        return View("Create");
    }

    public IActionResult Details()
    {
        return View("Details");
    }

    public IActionResult Edit()
    {
        return View("Edit");
    }

    public IActionResult VerificationWork()
    {
        return View("VerificationWork");
    }
    public IActionResult VerificationProject()
    {
        return View("VerificationProject");
    }
}
