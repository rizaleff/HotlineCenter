using API.Dtos.CsTasks;
using API.Dtos.Divisions;
using API.Models;

namespace API.Dtos.Projects;
public class ProjectDto
{
    public Guid Guid {  get; set; }
    public Guid ReportGuid { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsApprove { get; set; }
    public float Budget { get; set; }


    public static implicit operator Project(ProjectDto projectDto)
    {
        return new Project
        {
            Guid = projectDto.Guid,
            ReportGuid = projectDto.ReportGuid,
            Title = projectDto.Title,
            Description = projectDto.Description,
            IsApprove = projectDto.IsApprove,
            Budget = projectDto.Budget,
            ModifiedDate = DateTime.Now
        };
    }
    public static explicit operator ProjectDto(Project project)
    {
        return new ProjectDto
        {
            Guid = project.Guid,
            ReportGuid = project.ReportGuid,
            Title = project.Title,
            Description = project.Description,
            IsApprove = project.IsApprove,
            Budget = project.Budget
        };
    }
}
