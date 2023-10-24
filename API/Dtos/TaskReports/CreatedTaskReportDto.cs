using API.Dtos.Roles;
using API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Dtos.TaskReports;
public class CreatedTaskReportDto
{
    public bool IsFinish { get; set; }
    public string Description { get; set; }
    public int Photo { get; set; }


    public static implicit operator TaskReport(CreatedTaskReportDto createdTaskReportDto)
    {
        return new TaskReport
        {
            Description = createdTaskReportDto.Description,
            Photo = createdTaskReportDto.Photo,
            IsFinish = createdTaskReportDto.IsFinish,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }
}