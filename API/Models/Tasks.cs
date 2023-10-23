using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_tasks")]
public class Tasks : BaseEntity
{
    [Column("title", TypeName = "nvarchar(100)")]
    public string Title { get; set; }

    [Column("description", TypeName = "nvarchar(max)")]
    public string Description { get; set; }

    [Column("task_estimate")]
    public DateTime TaskEstimate { get; set; }

    [Column("is_approved")]
    public bool IsApproved { get; set; }

    // Cardinality
    public Reports? Report { get; set; }
    public TaskReports? TaskReport { get; set; }
    public CsTasks? CsTask { get; set; }
}