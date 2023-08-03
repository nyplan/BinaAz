namespace BinaAz.Application.DTOs.User;

public record RegisterWithEmailDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PasswordConfirm { get; set; } = null!;
}