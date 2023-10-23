using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;
public class DivisionRepository : GeneralRepository<Division>, IDivisionRepository
{
    public DivisionRepository(HotlineCenterDbContext context) : base(context) { }

}