namespace API.Dtos.Accounts;

public class ForgotPasswordDto
{
    public string Email { get; set; }

    public int Otp { get; set; }

    public DateTime ExpiredDate { get; set; }
}