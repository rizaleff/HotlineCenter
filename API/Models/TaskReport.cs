using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_task_reports")]
public class TaskReport : BaseEntity
{
    [Column("is_finish")]
    public bool IsFinish { get; set; }

    [Column("description", TypeName = "nvarchar(max)")]
    public string Description { get; set; }

    [Column("photo")]
    public int Photo { get; set; }

    // Cardinality
    public Task? Task { get; set; }
}