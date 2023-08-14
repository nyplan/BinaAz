using BinaAz.Domain.Entities.TPH.Base;

namespace BinaAz.Domain.Entities;

public class District
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int CityId { get; set; }
    public City? City { get; set; }
    
    public ICollection<Settlement>? Settlements { get; set; }
    public ICollection<Item>? Items { get; set; }
}