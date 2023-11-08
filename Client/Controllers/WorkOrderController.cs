using API.Dtos.Reports;
using API.Dtos.WorkOrders;
using API.DTOs.Employees;
using API.DTOs.Reports;
using API.DTOs.WorkOrders;
using Client.Contracts;
using Client.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Client.Controllers;
public class WorkOrderController : Controller
{

    private readonly ICsEmployeeRepository _csEmployeeRepository;
    private readonly ICreateWorkOrderRepository _createWorkOrderRepository;
    private readonly IWorkOrderRepository _workOrderRepository;
    private readonly IWorkOrderDetailRepository _workOrderDetailRepository;



    public WorkOrderController(ICsEmployeeRepository csEmployeeRepository, ICreateWorkOrderRepository createWorkOrderRepository, IWorkOrderRepository workOrderRepository, IWorkOrderDetailRepository workOrderDetailRepository)
    {

        _csEmployeeRepository = csEmployeeRepository;
        _createWorkOrderRepository = createWorkOrderRepository;
        _workOrderRepository = workOrderRepository;
        _workOrderDetailRepository = workOrderDetailRepository;
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

    [Authorize(Roles = "GA")]
    [HttpPost]
    public async Task<JsonResult> ToCreate(CreateWorkOrderDto createWorkOrderDto)
    {

        var result = await _createWorkOrderRepository.Post(createWorkOrderDto);
        return Json(result.Data);
    }

    [Authorize(Roles = "GA")]
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

    [Authorize(Roles = "CS")]
    public async Task<JsonResult> GetWorkOrderByEmployeeGuid(Guid employeeGuid)

    {
        var result = await _workOrderRepository.GetWorkOrderByEmployeeGuid(employeeGuid); // Mengambil data WorkOrder berdasarkan EmployeeGuid
        return Json(result.Data);

    }
    
    public async Task<JsonResult> GetWorkOrderDetails(Guid guid)

    {
        var result = await _workOrderDetailRepository.Get(guid); 
            return Json(result.Data);
    }

    public async Task<JsonResult> UpdateStatus(UpdateStatusWorkOrderDto workOrderDto)

    {
        var result = await _workOrderRepository.UpdateStatus(workOrderDto);
        return Json(result.Data);
    }

}
