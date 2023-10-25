using API.Dtos.Accounts;
using API.Dtos.Employees;
using API.Models;

namespace API.Dtos.CsTasks;
public class CsTaskDto
{
    public Guid Guid { get; set; }
    public Guid CsGuid { get; set; }
    public Guid TaskGuid { get; set; }

    public static implicit operator CsWorkOrder(CsTaskDto csTaskDto)
    {
        return new CsWorkOrder
        {
            Guid = csTaskDto.Guid,
            CsGuid = csTaskDto.CsGuid,
            WorkOrderGuid = csTaskDto.TaskGuid,
            ModifiedDate = DateTime.Now
        };
    }
    public static explicit operator CsTaskDto(CsWorkOrder csTask)
    {
        return new CsTaskDto
        {
            Guid = csTask.Guid,
            CsGuid = csTask.Guid,
            TaskGuid = csTask.WorkOrderGuid,
        };
    }
}
