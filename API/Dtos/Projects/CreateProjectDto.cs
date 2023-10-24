using API.Dtos.Employees;
using API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Dtos.Projects;
public class CreateProjectDto
{
    public Guid ReportGuid { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsApprove { get; set; }
    public float Budget { get; set; }

    public static implicit operator Project(CreateProjectDto createProjectDto)
    {
        return new Project
        {
            ReportGuid = createProjectDto.ReportGuid,
            Title = createProjectDto.Title,
            Description = createProjectDto.Description,
            IsApprove = createProjectDto.IsApprove,
            Budget = createProjectDto.Budget,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }
}
