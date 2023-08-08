namespace BinaAz.Application.DTOs.User;

public class RegisterAsAgencyEmailDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PasswordConfirm { get; set; } = null!;
    public string CompanyName { get; set; } = null!;
    public string RelevantPerson { get; set; } = null!;
}