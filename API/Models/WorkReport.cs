using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_task_reports")]
public class WorkReport : BaseEntity
{
    [Column("is_finish")]
    public bool IsFinish { get; set; }

    [Column("description", TypeName = "nvarchar(max)")]
    public string Description { get; set; }

    [Column("photo", TypeName = "nvarchar(max)")]
    public int Photo { get; set; }

    [Column("note", TypeName = "nvarchar(max)")]
    public string? Note { get; set; }

    // Cardinality
    public WorkOrder? WorkOrder { get; set; }
}