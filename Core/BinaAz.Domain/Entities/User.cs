using BinaAz.Domain.Entities.Common;
using BinaAz.Domain.Entities.TPH.Base;

namespace BinaAz.Domain.Entities;

public class User : BaseEntity
{
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string HashedPassword { get; set; } = null!;
    public string Salt { get; set; } = null!;
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpires { get; set; }
    public double Balance { get; set; }
    public List<Item> Items { get; set; } = new();

    public Guid? ImageId { get; set; }
    public Image? Image { get; set; }
}