namespace API.Dtos.Tasks;

using API.Dtos.CsTasks;
using WorkOrder = Models.WorkOrder;
public class WorkOrderDto
{
    public Guid Guid { get; set; }
    public Guid ReportGuid { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime TaskEstimate { get; set; }
    public bool IsApproved { get; set; }

    public static implicit operator WorkOrder(WorkOrderDto workOrderDto)
    {
        return new WorkOrder
        {
            Guid = workOrderDto.Guid,
            ReportGuid = workOrderDto.ReportGuid,
            Title = workOrderDto.Title,
            Description = workOrderDto.Description,
            TaskEstimate = workOrderDto.TaskEstimate,
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
            Title = workOrder.Title,
            Description = workOrder.Description,
            TaskEstimate = workOrder.TaskEstimate,
            IsApproved = workOrder.IsApproved
        };
    }
}
