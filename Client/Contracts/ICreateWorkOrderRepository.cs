using API.Dtos.Reports;
using API.Dtos.WorkOrders;

namespace Client.Contracts;
public interface ICreateWorkOrderRepository : IRepository<CreateWorkOrderDto, Guid>
{


}
