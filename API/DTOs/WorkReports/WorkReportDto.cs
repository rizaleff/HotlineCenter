using API.Models;

namespace API.Dtos.TaskReports;
public class WorkReportDto
{
    Guid Guid { get; set; }
    public bool IsFinish { get; set; }
    public string Description { get; set; }
    public int Photo { get; set; }


    public static implicit operator WorkReport(WorkReportDto workReportDto)
    {
        return new WorkReport
        {
            Guid = workReportDto.Guid,
            Description = workReportDto.Description,
            Photo = workReportDto.Photo,
            IsFinish = workReportDto.IsFinish,
            ModifiedDate = DateTime.Now
        };
    }


    public static explicit operator WorkReportDto(WorkReport workReport)
    {
        return new WorkReportDto
        {
            Guid = workReport.Guid,
            Description = workReport.Description,
            Photo = workReport.Photo,
            IsFinish = workReport.IsFinish,
        };
    }
}
