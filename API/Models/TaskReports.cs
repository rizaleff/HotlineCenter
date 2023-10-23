using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_task_reports")]
public class TaskReports : BaseEntity
{
    [Column("is_finish")]
    public bool IsFinish { get; set; }

    [Column("description", TypeName = "nvarchar(max)")]
    public string Description { get; set; }

    [Column("photo")]
    public int Photo { get; set; }

    // Cardinality
    public Tasks? Task { get; set; }
}