using API.Dtos.Roles;
using API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Dtos.WorkReports;
public class CreateWorkReportDto
{
    public string Title { get; set; }
    public Guid EmployeeGuid { get; set; }
    public Guid WorkOrderGuid { get; set; }
    public bool IsFinish { get; set; }
    public string Description { get; set; }
    public byte[] Photo { get; set; }


    public static implicit operator WorkReport(CreateWorkReportDto createdWorkReportDto)
    {
        return new WorkReport
        {
            EmployeeGuid = createdWorkReportDto.EmployeeGuid,
            WorkOrderGuid = createdWorkReportDto.WorkOrderGuid,
            Title = createdWorkReportDto.Title,
            Description = createdWorkReportDto.Description,
            Photo = createdWorkReportDto.Photo,
            IsFinish = createdWorkReportDto.IsFinish,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }
}