using API.Models;

namespace API.Dtos.TaskReports;
public class TaskReportDto
{
    Guid Guid { get; set; }
    public bool IsFinish { get; set; }
    public string Description { get; set; }
    public int Photo { get; set; }


    public static implicit operator TaskReport(TaskReportDto taskReportDto)
    {
        return new TaskReport
        {
            Guid = taskReportDto.Guid,
            Description = taskReportDto.Description,
            Photo = taskReportDto.Photo,
            IsFinish = taskReportDto.IsFinish,
            ModifiedDate = DateTime.Now
        };
    }


    public static explicit operator TaskReportDto(TaskReport taskReport)
    {
        return new TaskReportDto
        {
            Guid = taskReport.Guid,
            Description = taskReport.Description,
            Photo = taskReport.Photo,
            IsFinish = taskReport.IsFinish,
        };
    }
}
