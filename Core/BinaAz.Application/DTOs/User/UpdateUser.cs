namespace BinaAz.Application.DTOs.User;

public class UpdateUser
{
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? CurrentPassword { get; set; }
    public string? NewPassword { get; set; }
    public string? NewPasswordConfirm { get; set; }
}