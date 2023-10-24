using API.Dtos.Roles;
using API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using WorkOrder = API.Models.WorkOrder;

namespace API.Dtos.Tasks;
public class CreateWorkOrderDto
{
    public Guid ReportGuid { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime TaskEstimate { get; set; }
    public bool IsApproved { get; set; }

    public static implicit operator WorkOrder(CreateWorkOrderDto createTaskDto)
    {
        return new WorkOrder
        {
            ReportGuid = createTaskDto.ReportGuid,
            Title = createTaskDto.Title,
            Description = createTaskDto.Description,
            TaskEstimate = createTaskDto.TaskEstimate,
            IsApproved = createTaskDto.IsApproved,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

}
