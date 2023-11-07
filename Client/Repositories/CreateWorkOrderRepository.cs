using API.Dtos.Reports;
using API.Dtos.WorkOrders;
using Client.Contracts;

namespace Client.Repositories;
public class CreateWorkOrderRepository : GeneralRepository<CreateWorkOrderDto, Guid>, ICreateWorkOrderRepository
{
    public CreateWorkOrderRepository(string request = "WorkOrder/") : base(request)
    {

    }
}
