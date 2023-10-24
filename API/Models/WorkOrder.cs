using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_tasks")]
public class WorkOrder : BaseEntity
{
    [Column("report_guid")]
    public Guid ReportGuid { get; set; }

    [Column("title", TypeName = "nvarchar(100)")]
    public string Title { get; set; }

    [Column("description", TypeName = "nvarchar(max)")]
    public string Description { get; set; }

    [Column("task_estimate")]
    public DateTime TaskEstimate { get; set; }

    [Column("is_approved")]
    public bool IsApproved { get; set; }

    [Column("note", TypeName = "nvarchar(max)")]
    public string Note { get; set; }

    // Cardinality
    public Report? Report { get; set; }
    public WorkReport? WorkReport { get; set; }
    public ICollection<CsTask>? CsTasks { get; set; }
}