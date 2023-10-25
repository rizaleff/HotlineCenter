using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;
[Table("tb_m_employees")]
public class Employee : BaseEntity
{
    [Column("nik", TypeName = "nchar(6)")]
    public string Nik { get; set; }
    [Column("first_name", TypeName = "nvarchar(100)")]
    public string FirstName { get; set; }
    [Column("last_name", TypeName = "nvarchar(100)")]
    public string LastName { get; set; }
    [Column("birth_date")]
    public DateTime BirthDate { get; set; }
    [Column("gender")]
    public GenderLevel Gender { get; set; }
    [Column("hiring_date")]
    public DateTime HiringDate { get; set; }
    [Column("email", TypeName = "nvarchar(100)")]
    public string Email { get; set; }

    [Column("phone_number", TypeName = "nvarchar(50)")]
    public string PhoneNumber { get; set; }

    [Column("division_guid")]
    public Guid DivisionGuid{ get; set; }

    [Column("photo_url")]
    public string PhotoUrl { get; set; }
    
    //Cardinality
    public Account? Account { get; set; }
    public Division? Division { get; set; }
    public ICollection<CsTask>? CsTasks { get; set; }
    public ICollection<Report>? Reports { get; set; }
}
