using API.Dtos.Accounts;
using API.Dtos.Employees;
using API.Models;

namespace API.Dtos.CsTasks;
public class CsTaskDto
{
    public Guid Guid { get; set; }
    public Guid CsGuid { get; set; }
    public Guid TaskGuid { get; set; }

    public static implicit operator CsTask(CsTaskDto csTaskDto)
    {
        return new CsTask
        {
            Guid = csTaskDto.Guid,
            CsGuid = csTaskDto.CsGuid,
            TaskGuid = csTaskDto.TaskGuid,
            ModifiedDate = DateTime.Now
        };
    }
    public static explicit operator CsTaskDto(CsTask csTask)
    {
        return new CsTaskDto
        {
            Guid = csTask.Guid,
            CsGuid = csTask.Guid,
            TaskGuid = csTask.TaskGuid,
        };
    }
}
