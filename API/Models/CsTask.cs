using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_cs_tasks")]
public class CsTask : BaseEntity
{
    [Column("cs_guid")]
    public Guid CsGuid { get; set; }

    [Column("work_order_guid")]
    public Guid WorkOrderGuid { get; set; }

    // Cardinality
    public Employee? Employee { get; set; }
    public WorkOrder? Task { get; set; }
}