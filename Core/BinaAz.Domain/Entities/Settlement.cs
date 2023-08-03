namespace BinaAz.Domain.Entities;

public class Settlement
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int DistrictId { get; set; }
    public District? District { get; set; }
}