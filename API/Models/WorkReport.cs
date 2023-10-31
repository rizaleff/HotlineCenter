using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_work_reports")]
public class WorkReport : BaseEntity
{
    [Column("title", TypeName = "nvarchar(max)")]
    public string Title { get; set; }

    [Column("is_finish")]
    public bool IsFinish { get; set; }

    [Column("description", TypeName = "nvarchar(max)")]
    public string Description { get; set; }

    [Column("photo", TypeName = "nvarchar(max)")]
    public byte[] Photo { get; set; }

    [Column("note", TypeName = "nvarchar(max)")]
    public string? Note { get; set; }

    [Column("work_order_guid")]
    public Guid? WorkOrderGuid { get; set; }


    [Column("employee_guid")]
    public Guid? EmployeeGuid { get; set; }
    //Subject
    //EmployeeGuid : Sama kayak report


    // Cardinality
    public WorkOrder? WorkOrder { get; set; }

    public Employee? Employee { get; set; }
}