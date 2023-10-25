using API.Utilities.Enums;

namespace API.DTOs.Reports;
public class ReportDetailDto
{
    public Guid Guid { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string EmployeeFullName { get; set; }
    public StatusLevel Status { get; set; }
    //public string ReportPhotoUrl { get; set; }
    //public string EmployeePhotoUrl { get; set; }
    
    public byte[] ReportPhoto {  get; set; }
    public byte[] EmployeePhoto {  get; set; }
    public DateTime CreatedDate {  get; set; }
    public DateTime ModifiedDate {  get; set; }
}
