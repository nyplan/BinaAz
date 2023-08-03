namespace BinaAz.Domain.Entities;

public class EnumKey
{
    public int Id { get; set; }
    public string Key { get; set; } = null!;
    public ICollection<EnumValue>? Values { get; set; }
}