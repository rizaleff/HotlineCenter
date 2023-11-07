using API.Contracts;
using API.Data;
using API.Dtos.Tasks;
using API.Models;
using API.Utilities.Enums;

namespace API.Repositories;
public class WorkOrderRepository : GeneralRepository<Models.WorkOrder>, IWorkOrderRepository
{
    public WorkOrderRepository(HotlineCenterDbContext context) : base(context) { }

    public IEnumerable<WorkOrderDetailDto>? GetWoDetailByEmpGuid(Guid employeeGuid)
    {
        var query = from workOrder in _context.WorkOrders
                    join report in _context.Reports
                    on workOrder.ReportGuid equals report.Guid
                    where workOrder.EmployeeGuid == employeeGuid
                    select new WorkOrderDetailDto
                    {
                        Guid = workOrder.Guid,
                        Title = workOrder.Title,
                        Description = workOrder.Description,
                        ReportGuid = workOrder.ReportGuid,
                        Status = workOrder.Status,
                        ReportDescription = report.Description,
                        ReportPhoto = report.Photo,
                        CreatedDate = workOrder.CreatedDate
                    };

        return query.ToList();
    }
    public IEnumerable<WorkOrder>? GetWorkOrderByEmployee(Guid employeeGuid)
    {
        return _context.Set<WorkOrder>().Where(r => r.EmployeeGuid == employeeGuid).ToList();
    }



    /*
     * var query = from order in dbContext.Orders
                            join customer in dbContext.Customers on order.CustomerId equals customer.CustomerId
                            where order.CustomerId == customerId && order.OrderDate >= startDate && order.OrderDate <= endDate
                            select order;
     */

}