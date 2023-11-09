using API.Models;
using API.Utilities.Enums;

namespace API.Dtos.Reports;
public class ReportDto
{
    public Guid Guid { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public StatusLevel Status { get; set; }
    public DateTime CreatedDate { get; set; }
    //public string PhotoUrl { get; set; }

    public static implicit operator Report(ReportDto reportDto)
    {
        return new Report
        {
            Guid = reportDto.Guid,
            Title = reportDto.Title,
            Description = reportDto.Description,
            Status = reportDto.Status,
            //PhotoUrl = reportDto.PhotoUrl,
            
        };
    }
    public static explicit operator ReportDto(Report report)
    {
        return new ReportDto
        {
            Guid = report.Guid,
            Title = report.Title,
            Description = report.Description,
            Status = report.Status,
            CreatedDate = report.CreatedDate,
            //PhotoUrl = report.PhotoUrl
        };
    }
}
