using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_roles")]
public class Roles : BaseEntity
{
    [Column("name", TypeName = "nvarchar(100)")]
    public string Name { get; set; }

    // Cardinality
    public AccountRoles? AccountRole { get; set; }
}