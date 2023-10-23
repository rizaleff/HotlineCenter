using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;
[Table("tb_reports")]
public class Reports : BaseEntity
{
    [Column("title", TypeName = "nvarchar(100)")]
    public string Title { get; set; }

    [Column("description", TypeName = "nvarchar(max)")]
    public string Description{ get; set; }

    [Column("employee_guid")]
    public Guid EmployeeGuid { get; set; }

    [Column("gender")]
    public StatusLevel Status { get; set; }

    [Column("photo_url", TypeName = "nvarchar(max)")]
    public string PhotoUrl { get; set; }
}
