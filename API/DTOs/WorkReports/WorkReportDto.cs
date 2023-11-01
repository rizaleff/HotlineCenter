using API.Models;

namespace API.Dtos.WorkReports;
public class WorkReportDto
{
    public string Title { get; set; }
    public Guid Guid { get; set; }
    public bool IsFinish { get; set; }
    public string Description { get; set; }


    public static implicit operator WorkReport(WorkReportDto workReportDto)
    {
        return new WorkReport
        {
            Guid = workReportDto.Guid,
            Title = workReportDto.Title,
            Description = workReportDto.Description,
            IsFinish = workReportDto.IsFinish,
            ModifiedDate = DateTime.Now
        };
    }


    public static explicit operator WorkReportDto(WorkReport workReport)
    {
        return new WorkReportDto
        {
            Guid = workReport.Guid,
            Title = workReport.Title,
            Description = workReport.Description,
            IsFinish = workReport.IsFinish,
        };
    }
}
