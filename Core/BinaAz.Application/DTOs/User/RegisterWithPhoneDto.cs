namespace BinaAz.Application.DTOs.User;

public class RegisterWithPhoneDto
{
    public string Phone { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PasswordConfirm { get; set; } = null!;
}