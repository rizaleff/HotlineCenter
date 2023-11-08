using API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Dtos.WorkReports;
public class WorkReportDto
{
    public string Title { get; set; }
    public Guid Guid { get; set; }
    public string Description { get; set; }
    public bool IsFinish { get; set; }
    public byte[] Photo { get; set; }
    public string? Note { get; set; }
    public Guid? WorkOrderGuid { get; set; }
    public DateTime CreatedDate {  get; set; }


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
            Photo = workReport.Photo,
            Note = workReport.Note,
            WorkOrderGuid = workReport.WorkOrderGuid,
            CreatedDate = workReport.CreatedDate
        };
    }
}
