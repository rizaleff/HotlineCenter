﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace API.Models;
[Table("tb_account_roles")]
public class AccountRole : BaseEntity
{
    [Column("account_guid", TypeName = "uniqueidentifier")]
    public Guid AccountGuid { get; set; }
    [Column("role_guid", TypeName = "uniqueidentifier")]
    public Guid RoleGuid { get; set; }

    //Cardinality
    public Account? Account { get; set; }
    public Role? Role { get; set; }
}