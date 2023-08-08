namespace BinaAz.Application.DTOs.User;

public class RegisterAsResidentialComplexPhoneDto
{
    public string Phone { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PasswordConfirm { get; set; } = null!;
    public string CompanyName { get; set; } = null!;
    public string RelevantPerson { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int HandOverYear { get; set; }
}