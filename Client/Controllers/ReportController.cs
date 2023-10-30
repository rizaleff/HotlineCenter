using API.Dtos.Employees;
using API.Dtos.Reports;
using API.DTOs.Reports;
using Client.Contracts;
using Client.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Client.Controllers
{
    public class ReportController : Controller
    {

        private readonly ICreateReportRepository _createReportRepository;
        private readonly IDetailReportRepository _detailReportRepository;
        public ReportController(ICreateReportRepository createReportRepository, IDetailReportRepository detailReportRepository)
        {
            _createReportRepository = createReportRepository;
            _detailReportRepository = detailReportRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReceiveReportDto reportDto)
        {

            CreateReportDto createReportDto = new CreateReportDto();
            createReportDto.Title = reportDto.Title;
            createReportDto.Description = reportDto.Description;
            createReportDto.EmployeeGuid = reportDto.EmployeeGuid;

            if (reportDto.PhotoFile != null && reportDto.PhotoFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    reportDto.PhotoFile.CopyTo(memoryStream);
                    createReportDto.PhotoFile = memoryStream.ToArray();
                }
            }
            var result = await _createReportRepository.Post(createReportDto); ;
            if (result.Code == 200)
            {
                return RedirectToAction("Index", "Employee" );
            }
            ModelState.AddModelError(string.Empty, result.Message);
            return View();
        }


        public async Task<IActionResult> Details(Guid guid)
        {
            var result = await _detailReportRepository.Get(guid);
            var selectedReport = new ReportDetailDto();
            if (result.Data != null)
            {
                selectedReport = result.Data;
            }
            return View("Details", selectedReport);
        }

        public IActionResult Edit()
        {
            return View("Edit");
        }
    }
}
