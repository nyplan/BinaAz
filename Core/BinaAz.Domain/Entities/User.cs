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
    public string? ImageUrl { get; set; }

    public bool? IsAgency { get; set; }
    public string? CompanyName { get; set; }
    public string? RelevantPerson { get; set; }
    
    public bool? IsResidentialComplex { get; set; }
    public string? Address { get; set; }
    public int? HandOverYear { get; set; }
    
    public List<Item> Items { get; set; } = new();
    public List<Item> Liked { get; set; } = new();
}