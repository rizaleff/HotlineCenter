using API.Dtos.Employees;
using API.Models;

namespace API.Dtos.CsTasks;
public class CreateCsTaskDto
{
    public Guid CsGuid { get; set; }
    public Guid TaskGuid { get; set; }

    public static implicit operator CsWorkOrder(CreateCsTaskDto createCsTaskDto)
    {
        return new CsWorkOrder
        {
            CsGuid = createCsTaskDto.CsGuid,
            WorkOrderGuid = createCsTaskDto.TaskGuid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }
}
