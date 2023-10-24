using API.Models;
using WorkOrder = API.Models.WorkOrder;

namespace API.Contracts;
public interface IWorkOrderRepository : IGeneralRepository<WorkOrder>
{

}
