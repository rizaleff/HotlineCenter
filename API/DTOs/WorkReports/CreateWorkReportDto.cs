using API.Dtos.Roles;
using API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Dtos.WorkReports;
public class CreateWorkReportDto
{
    public bool IsFinish { get; set; }
    public string Description { get; set; }
    public byte[] Photo { get; set; }


    public static implicit operator WorkReport(CreateWorkReportDto createdWorkReportDto)
    {
        return new WorkReport
        {
            Description = createdWorkReportDto.Description,
            Photo = createdWorkReportDto.Photo,
            IsFinish = createdWorkReportDto.IsFinish,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }
}