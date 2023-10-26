using API.Dtos.Reports;
using Client.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Client.Controllers
{
    public class ReportController : Controller
    {

        private readonly IReportRepository repository;
        public ReportController(IReportRepository repository)
        {
            this.repository = repository;
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
            var result = await repository.Post(createReportDto); ;
            if (result.Code == 200)
            {
                return RedirectToAction("Employee", "Index");
            }
            ModelState.AddModelError(string.Empty, result.Message);
            return View();
        }


        public IActionResult Details()
        {
            return View("Details");
        }

        public IActionResult Edit()
        {
            return View("Edit");
        }
    }
}
