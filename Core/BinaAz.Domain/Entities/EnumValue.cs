namespace BinaAz.Domain.Entities;

public class EnumValue
{
    public int Id { get; set; }
    public string Value { get; set; } = null!;
    public int KeyId { get; set; }
    public EnumKey? Key { get; set; }
}