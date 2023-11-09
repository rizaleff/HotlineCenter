namespace API.Dtos.WorkOrders;

using API.Dtos.CsTasks;
using API.Utilities.Enums;
using WorkOrder = Models.WorkOrder;
public class WorkOrderDto
{
    public Guid Guid { get; set; }
    public Guid ReportGuid { get; set; }
    public Guid? EmployeeGuid { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public StatusWorkOrderLevel Status { get; set; }
    public DateTime TaskEstimate { get; set; }
    public bool IsApproved { get; set; }

    public static implicit operator WorkOrder(WorkOrderDto workOrderDto)
    {
        return new WorkOrder
        {
            Guid = workOrderDto.Guid,
            ReportGuid = workOrderDto.ReportGuid,
            EmployeeGuid = workOrderDto.EmployeeGuid,
            Title = workOrderDto.Title,
            Description = workOrderDto.Description,
            TaskEstimate = workOrderDto.TaskEstimate,
            Status = workOrderDto.Status,
            IsApproved = workOrderDto.IsApproved,
            ModifiedDate = DateTime.Now

        };
    }

    public static explicit operator WorkOrderDto(WorkOrder workOrder)
    {
        return new WorkOrderDto
        {
            Guid = workOrder.Guid,
            ReportGuid = workOrder.ReportGuid,
            EmployeeGuid = workOrder.EmployeeGuid,
            Title = workOrder.Title,
            Description = workOrder.Description,
            Status = workOrder.Status,
            TaskEstimate = workOrder.TaskEstimate,
            IsApproved = workOrder.IsApproved
        };
    }
}
