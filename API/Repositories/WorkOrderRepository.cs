using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;
public class WorkOrderRepository : GeneralRepository<Models.WorkOrder>, IWorkOrderRepository
{
    public WorkOrderRepository(HotlineCenterDbContext context) : base(context) { }

}