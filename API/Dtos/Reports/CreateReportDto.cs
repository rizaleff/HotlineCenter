using API.Dtos.Projects;
using API.Models;
using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Dtos.Reports;
public class CreateReportDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid EmployeeGuid { get; set; }
    //public string PhotoUrl { get; set; }
    public byte[] PhotoFile { get; set; }

    public static implicit operator Report(CreateReportDto createReportDto)
    {
        return new Report
        {
            Title = createReportDto.Title,
            Description = createReportDto.Description,
            EmployeeGuid = createReportDto.EmployeeGuid,
            Status = 0,
            Photo = createReportDto.PhotoFile,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }
}
