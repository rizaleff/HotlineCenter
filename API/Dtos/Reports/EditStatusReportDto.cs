using API.Models;
using API.Utilities.Enums;

namespace API.Dtos.Reports;
public class EditStatusReportDto
{
    public Guid Guid { get; set; }
    public StatusLevel Status { get; set; }
    public string Note {  get; set; }

    public static implicit operator Report(EditStatusReportDto reportDto)
    {
        return new Report
        {
            Guid = reportDto.Guid,
            Status = reportDto.Status,
            Note = reportDto.Note,
            ModifiedDate = DateTime.Now
        };
    }
}
