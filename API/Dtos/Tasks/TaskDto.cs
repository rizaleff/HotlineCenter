namespace API.Dtos.Tasks;

using API.Dtos.CsTasks;
using Task = Models.Task;
public class TaskDto
{
    public Guid Guid { get; set; }
    public Guid ReportGuid { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime TaskEstimate { get; set; }
    public bool IsApproved { get; set; }

    public static implicit operator Task(TaskDto taskDto)
    {
        return new Task
        {
            Guid = taskDto.Guid,
            ReportGuid = taskDto.ReportGuid,
            Title = taskDto.Title,
            Description = taskDto.Description,
            TaskEstimate = taskDto.TaskEstimate,
            IsApproved = taskDto.IsApproved,
            ModifiedDate = DateTime.Now

        };
    }

    public static explicit operator TaskDto(Task task)
    {
        return new TaskDto
        {
            Guid = task.Guid,
            ReportGuid = task.ReportGuid,
            Title = task.Title,
            Description = task.Description,
            TaskEstimate = task.TaskEstimate,
            IsApproved = task.IsApproved
        };
    }
}
