using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;
[Table("tb_projects")]
public class Project : BaseEntity
{
    [Column("report_guid")]
    public Guid ReportGuid { get; set; }

    [Column("title", TypeName = "nvarchar(100)")]
    public string Title { get; set; }

    [Column("description", TypeName = "nvarchar(max)")]
    public string Description { get; set; }

    [Column("is_approve")]
    public bool IsApprove { get; set; }

    [Column("budget")]
    public float Budget { get; set; }

    [Column("note", TypeName = "nvarchar(max)")]
    public string? Note { get; set; }

    //Cardinality
    public Report? Report { get; set; }
    public WorkOrder? WorkOrder { get; set; }

}