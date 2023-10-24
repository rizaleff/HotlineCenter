using API.Dtos.CsTasks;
using API.Models;

namespace API.Dtos.Divisions;
public class CreateDivisionDto
{
    public string Name { get; set; }

    public static implicit operator Division(CreateDivisionDto createDivisionDto)
    {
        return new Division
        {
            Name = createDivisionDto.Name,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }
}
