using API.Dtos.Roles;
using API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using WorkOrder = API.Models.WorkOrder;

namespace API.Dtos.Tasks;
public class CreateWorkOrderDto
{
    public Guid EmployeeGuid { get; set; }
    public Guid ReportGuid { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CsEmployeeGuid { get; set; }


    public static implicit operator WorkOrder(CreateWorkOrderDto createTaskDto)
    {
        return new WorkOrder
        {
            EmployeeGuid = createTaskDto.EmployeeGuid,
            ReportGuid = createTaskDto.ReportGuid,
            Title = createTaskDto.Title,
            Description = createTaskDto.Description,
            EmployeeGuid = createTaskDto.CsEmployeeGuid,
            Status = 0,
            IsApproved = false,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

}
