namespace BinaAz.Domain.Entities.TPH;

public class Office : Item
{
    public int TypeOfBuildingId { get; set; }
    public EnumValue? TypeOfBuilding { get; set; }
}