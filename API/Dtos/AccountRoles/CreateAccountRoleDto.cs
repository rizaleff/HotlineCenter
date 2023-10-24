﻿using API.Models;

namespace API.Dtos.AccountRoles;
public class CreateAccountRoleDto
{
   
    public Guid AccountGuid { get; set; }
    public Guid RoleGuid { get; set; }

    public static implicit operator AccountRole(CreateAccountRoleDto createAccountRoleDto)
    {
        return new AccountRole
        {
            AccountGuid = createAccountRoleDto.AccountGuid,
            RoleGuid = createAccountRoleDto.RoleGuid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }
}