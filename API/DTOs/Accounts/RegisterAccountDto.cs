using API.Models;
using API.Utilities.Enums;

namespace API.Dtos.Accounts;
public class RegisterAccountDto
{
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderLevel Gender { get; set; }
    public DateTime HiringDate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Guid RoleGuid {  get; set; }
    public int Otp { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

    public static implicit operator Account(RegisterAccountDto accountDto)
    {
        return new()
        {
            Guid = Guid.NewGuid(),
            Password = accountDto.ConfirmPassword,
            Otp = 0,
            IsUsed = true,
            ExpiredTime = DateTime.Now,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

    public static implicit operator Employee(RegisterAccountDto registerAccountDto)
    {
        return new()
        {
            FirstName = registerAccountDto.FirstName,
            LastName = registerAccountDto.LastName,
            BirthDate = registerAccountDto.BirthDate,
            Gender = registerAccountDto.Gender,
            HiringDate = registerAccountDto.HiringDate,
            Email = registerAccountDto.Email,
            PhoneNumber = registerAccountDto.PhoneNumber,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

    //public static implicit operator University(RegisterAccountDto registerAccountDto)
    //{
    //    return new()
    //    {
    //        Code = registerAccountDto.UniversityCode,
    //        Name = registerAccountDto.UniversityName,
    //        CreatedDate = DateTime.Now,
    //        ModifiedDate = DateTime.Now
    //    };
    //}

    //public static implicit operator Education(RegisterAccountDto registerAccountDto)
    //{
    //    return new()
    //    {
    //        Guid = Guid.NewGuid(),
    //        Major = registerAccountDto.Major,
    //        Degree = registerAccountDto.Degree,
    //        Gpa = registerAccountDto.Gpa,
    //        UniversityGuid = Guid.NewGuid(),
    //        CreatedDate = DateTime.Now,
    //        ModifiedDate = DateTime.Now
    //    };
    //}

    public static implicit operator AccountRole(RegisterAccountDto registerAccountDto)
    {
        return new()
        {
            Guid = Guid.NewGuid(),
            AccountGuid = Guid.NewGuid(),
            RoleGuid = Guid.NewGuid(),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }
}