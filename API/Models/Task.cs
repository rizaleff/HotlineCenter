using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_tasks")]
public class Task : BaseEntity
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

    // Cardinality
/*    public Report? Report { get; set; }
    public TaskReport? TaskReport { get; set; }
    public CsTask? CsTask { get; set; }*/
}