using API.Utilities.Enums;

namespace API.Dtos.WorkOrders;


public class WorkOrderDetailDto
{
    public Guid Guid { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid ReportGuid { get; set; }
    public StatusWorkOrderLevel Status { get; set; }
    public string ReportDescription { get; set; }
    public byte[] ReportPhoto {  get; set; }
    public DateTime CreatedDate {  get; set; }
}
