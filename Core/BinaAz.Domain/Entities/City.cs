namespace BinaAz.Domain.Entities;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<District>? Districts { get; set; }
}