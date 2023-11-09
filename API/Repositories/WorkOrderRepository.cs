using API.Contracts;
using API.Data;
using API.Dtos.WorkOrders;
using API.DTOs.WorkOrders;
using API.Models;
using API.Utilities.Enums;
using API.Utilities.Handlers;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;
public class WorkOrderRepository : GeneralRepository<Models.WorkOrder>, IWorkOrderRepository
{
    public WorkOrderRepository(HotlineCenterDbContext context) : base(context) { }

    public IEnumerable<WorkReportDetailDto>? GetWoDetailByEmpGuid(Guid employeeGuid)
    {
        var query = from workOrder in _context.WorkOrders
                    join report in _context.Reports
                    on workOrder.ReportGuid equals report.Guid
                    where workOrder.EmployeeGuid == employeeGuid
                    select new WorkReportDetailDto
                    {
                        Guid = workOrder.Guid,
                        Title = workOrder.Title,
                        Description = workOrder.Description,
                        ReportGuid = workOrder.ReportGuid,
                        Status = workOrder.Status,
                        ReportTitle = report.Title,
                        ReportDescription = report.Description,
                        ReportPhoto = report.Photo,
                        CreatedDate = workOrder.CreatedDate
                    };

        return query.ToList();
    }

    public IEnumerable<WorkReportDetailDto>? GetAllWoDetail()
    {
        var query = from workOrder in _context.WorkOrders
                    join report in _context.Reports
                    on workOrder.ReportGuid equals report.Guid
                    select new WorkReportDetailDto
                    {
                        Guid = workOrder.Guid,
                        Title = workOrder.Title,
                        Description = workOrder.Description,
                        ReportGuid = workOrder.ReportGuid,
                        Status = workOrder.Status,
                        ReportTitle = report.Title,
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

    public bool UpdateStatusWorkOrder(UpdateStatusWorkOrderDto workOrderDto)
    {
        try
        {
            var workOrderToUpdate = _context.WorkOrders.FirstOrDefault(wo => wo.Guid == workOrderDto.Guid);
            workOrderToUpdate.Status = workOrderDto.Status;
            workOrderToUpdate.ModifiedDate = DateTime.Now;

            // Simpan perubahan ke database
            _context.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {

            throw new ExceptionHandler(ex.InnerException?.Message ?? ex.Message);
        }
    }

    /*
     * var query = from order in dbContext.Orders
                            join customer in dbContext.Customers on order.CustomerId equals customer.CustomerId
                            where order.CustomerId == customerId && order.OrderDate >= startDate && order.OrderDate <= endDate
                            select order;
     */

}