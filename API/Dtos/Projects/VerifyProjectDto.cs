using API.Dtos.Reports;
using API.Models;

namespace API.Dtos.Projects;
public class VerifyProjectDto
{
    public Guid Guid { get; set; }
    public bool IsApproved {  get; set; }
    public string Note { get; set; }

    public static implicit operator Project(VerifyProjectDto verifyProjectDto)
    {
        return new Project
        {
            Guid = verifyProjectDto.Guid,
            IsApprove = verifyProjectDto.IsApproved,
            Note = verifyProjectDto.Note,
            ModifiedDate = DateTime.Now
        };
    }
}
