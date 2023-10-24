using API.Models;

namespace API.Dtos.TaskReports;
public class WorkReportDto
{
    Guid Guid { get; set; }
    public bool IsFinish { get; set; }
    public string Description { get; set; }
    public int Photo { get; set; }


    public static implicit operator WorkReport(WorkReportDto taskReportDto)
    {
        return new WorkReport
        {
            Guid = taskReportDto.Guid,
            Description = taskReportDto.Description,
            Photo = taskReportDto.Photo,
            IsFinish = taskReportDto.IsFinish,
            ModifiedDate = DateTime.Now
        };
    }


    public static explicit operator WorkReportDto(WorkReport taskReport)
    {
        return new WorkReportDto
        {
            Guid = taskReport.Guid,
            Description = taskReport.Description,
            Photo = taskReport.Photo,
            IsFinish = taskReport.IsFinish,
        };
    }
}
