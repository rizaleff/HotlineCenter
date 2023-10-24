using API.Dtos.CsTasks;
using API.Models;

namespace API.Dtos.Divisions;
public class DivisionDto
{
    public Guid Guid { get; set; }
    public string Name { get; set; }

    public static implicit operator Division(DivisionDto divisionDto)
    {
        return new Division
        {
            Guid = divisionDto.Guid,
            Name = divisionDto.Name,
            ModifiedDate = DateTime.Now
        };
    }
    public static explicit operator DivisionDto(Division division)
    {
        return new DivisionDto
        {
            Guid = division.Guid,
            Name = division.Name,
        };
    }

}
