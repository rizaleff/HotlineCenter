using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_cs_work_orders")]
public class CsWorkOrder : BaseEntity
{
    [Column("cs_guid")]
    public Guid CsGuid { get; set; }

    [Column("work_order_guid")]
    public Guid WorkOrderGuid { get; set; }

    // Cardinality
    public Employee? Employee { get; set; }
    public WorkOrder? WorkOrder { get; set; }
}