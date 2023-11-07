using API.Models;

namespace API.Contracts;
public interface IRoleRepository : IGeneralRepository<Role>
{
    Guid? GetGuidByName();
    Guid? GetDefaultRoleGuid();
}
