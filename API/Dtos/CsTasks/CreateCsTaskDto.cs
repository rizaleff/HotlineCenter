using API.Dtos.Employees;
using API.Models;

namespace API.Dtos.CsTasks;
public class CreateCsTaskDto
{
    public Guid CsGuid { get; set; }
    public Guid TaskGuid { get; set; }

    public static implicit operator CsTask(CreateCsTaskDto createCsTaskDto)
    {
        return new CsTask
        {
            CsGuid = createCsTaskDto.CsGuid,
            TaskGuid = createCsTaskDto.TaskGuid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }
}
