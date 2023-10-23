using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_cs_tasks")]
public class CsTask : BaseEntity
{
    [Column("cs_guid", TypeName = "uniqueidentifier")]
    public Guid CsGuid { get; set; }

    [Column("task_guid, TypeName = uniqueidentifier")]
    public Guid TaskGuid { get; set; }

    // Cardinality
/*    public Employee? Employee { get; set; }
    public Task? Task { get; set; }*/
}