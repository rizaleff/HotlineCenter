using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;
[Table("tb_division")]
public class Division : BaseEntity
{
    [Column("name", TypeName = "nvarchar(100)")]
    public string Name { get; set; }

    public ICollection<Employee>? Employees { get; set; }
}
