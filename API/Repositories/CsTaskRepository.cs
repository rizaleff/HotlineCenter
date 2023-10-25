using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;
public class CsTaskRepository : GeneralRepository<CsWorkOrder>, ICsTaskRepository
{
    public CsTaskRepository(HotlineCenterDbContext context) : base(context) { }

}