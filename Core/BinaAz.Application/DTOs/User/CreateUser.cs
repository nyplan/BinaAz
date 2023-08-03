namespace BinaAz.Application.DTOs.User;

public class CreateUser
{
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string Password { get; set; } = null!;
    public string PasswordConfirm { get; set; } = null!;
}