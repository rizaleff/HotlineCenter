using API.Models;

namespace API.Dtos.Accounts;
public class CreateAccountDto
{
    public string Password { get; set; }
    public int Otp { get; set; }
    public bool IsUsed { get; set; }
    public DateTime ExpiredTime { get; set; }

    public static implicit operator Account(CreateAccountDto createAccountDto)
    {
        return new Account
        {
            Password = createAccountDto.Password,
            Otp = createAccountDto.Otp,
            IsUsed = createAccountDto.IsUsed,
            ExpiredTime = createAccountDto.ExpiredTime,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }
}
