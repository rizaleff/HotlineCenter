using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;
public class RoleRepository : GeneralRepository<Role>, IRoleRepository
{
    public RoleRepository(HotlineCenterDbContext context) : base(context) { }

    public Guid? GetGuidByName()
    {
        return _context.Set<Role>().FirstOrDefault(r => r.Name == "Client")?.Guid;
    }
}