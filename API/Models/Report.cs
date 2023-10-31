using API.Dtos.Reports;
using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;
[Table("tb_reports")]
public class Report : BaseEntity
{
    [Column("title", TypeName = "nvarchar(100)")]
    public string Title { get; set; }

    [Column("description", TypeName = "nvarchar(max)")]
    public string Description{ get; set; }

    [Column("employee_guid")]
    public Guid EmployeeGuid { get; set; }

    [Column("status")]
    public StatusLevel Status { get; set; }

    /*[Column("photo_url", TypeName = "nvarchar(max)")]
    public string PhotoUrl { get; set; }*/

    [Column("photo")]
    public byte[] Photo { get; set; }

    [Column("note", TypeName = "nvarchar(max)")]
    public string? Note {  get; set; }

    //Cardinality
    public WorkOrder? WorkOrder {  get; set; }
    public Project? Project { get; set; }
    public Employee? Employee{ get; set; }
}
