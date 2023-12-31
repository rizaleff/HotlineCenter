﻿using API.Dtos.Reports;
using API.Dtos.WorkReports;
using Client.Contracts;
using Client.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class WorkReportController : Controller
    {
        private readonly IWorkReportRepository _workReportrepository;
        private readonly ICreateWorkReportRepository _createWorkReportRepository;
        public WorkReportController(IWorkReportRepository workReportRepository, ICreateWorkReportRepository createWorkReportReportRepository)
        {
                _workReportrepository = workReportRepository;
                _createWorkReportRepository = createWorkReportReportRepository;


        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "CS")]
        public async Task<JsonResult> GetWorkReportByEmployeeGuid(Guid employeeGuid)
        
        {
            var result = await _workReportrepository.GetWorkReportByEmployeeGuid(employeeGuid); // Mengambil data WorkReport berdasarkan EmployeeGuid
            return Json(result.Data);
        }

        [Authorize(Roles = "CS")]
        [HttpPost]
        public async Task<JsonResult> CreateWorkReport(CreateWorkReportDto createWorkReportDto)
        {
            var result = await _createWorkReportRepository.Post(createWorkReportDto);
            return Json(result);
        }

        public async Task<JsonResult> GetWorkReportDetails(Guid guid)

        {
            var result = await _workReportrepository.Get(guid);
            return Json(result.Data);
        }

    }
}
