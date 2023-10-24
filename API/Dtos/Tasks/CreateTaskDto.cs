using API.Dtos.Roles;
using API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Task = API.Models.Task;

namespace API.Dtos.Tasks;
public class CreateTaskDto
{
    public Guid ReportGuid { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime TaskEstimate { get; set; }
    public bool IsApproved { get; set; }

    public static implicit operator Task(CreateTaskDto createTaskDto)
    {
        return new Task
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
