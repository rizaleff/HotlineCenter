using Client.Contracts;
using Client.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class WorkReportController : Controller
    {
        private readonly IWorkReportRepository _workReportReportrepository;
        public WorkReportController(
                           IWorkReportRepository workReportRepository)
        {
                _workReportReportrepository = workReportRepository;
            
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<JsonResult> GetWorkReportByEmployeeGuid(Guid employeeGuid)
        
        {
            var result = await _workReportReportrepository.GetWorkReportByEmployeeGuid(employeeGuid); // Mengambil data WorkReport berdasarkan EmployeeGuid
            return Json(result.Data);
        }

    }
}
