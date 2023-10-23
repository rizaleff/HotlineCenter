using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_account_roles")]
public class AccountRoles : BaseEntity
{
    [Column("account_guid", TypeName = "uniqueidentifier")]
    public Guid AccountGuid { get; set; }

    [Column("role_guid", TypeName = "uniqueidentifier")]
    public Guid RoleGuid { get; set; }

    // Cardinality
    public Accounts? Account { get; set; }
    public Roles? Role { get; set; }
}