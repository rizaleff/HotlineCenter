namespace API.DTOs.WorkReports;
public class WorkReportDetailDto
{
    public string Title { get; set; }
    public Guid Guid { get; set; }
    public string Description { get; set; }
    public bool IsFinish { get; set; }
    public byte[] Photo { get; set; }
    public string? Note { get; set; }
    public Guid? ReportGuid { get; set; }
    public Guid? WorkOrderGuid { get; set; }
    public DateTime CreatedDate { get; set; }

}
