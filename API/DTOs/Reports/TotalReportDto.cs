using API.Utilities.Enums;

namespace API.DTOs.Reports;
public class TotalReportDto
{
    public StatusLevel Status { get; set; }
    public int Count { get; set; }
}
