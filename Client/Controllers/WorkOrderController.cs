using Client.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class WorkOrderController : Controller
    {
        private readonly IWorkOrderRepository _workOrderRepository;
        public WorkOrderController(
                           IWorkOrderRepository workOrderRepository)
        {
            _workOrderRepository = workOrderRepository;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
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

        public async Task<JsonResult> GetWorkOrderByEmployeeGuid(Guid employeeGuid)

        {
            var result = await _workOrderRepository.GetWorkOrderByEmployeeGuid(employeeGuid); // Mengambil data WorkOrder berdasarkan EmployeeGuid
            return Json(result.Data);
        } public async Task<JsonResult> GetWorkOrderDetails(Guid Guid)

        {
            var result = await _workOrderRepository.GetWorkOrderDetails(Guid); // Mengambil data WorkOrder berdasarkan EmployeeGuid
            return Json(result.Data);
        }
    }
}
