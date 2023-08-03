using BinaAz.Domain.Entities.Common;

namespace BinaAz.Domain.Entities;

public class User : BaseEntity
{
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string HashedPassword { get; set; } = null!;
    public string Salt { get; set; } = null!;
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpires { get; set; }
}