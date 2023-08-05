namespace BinaAz.Application.DTOs.Item.AddItem;

public record AddNewBuildingSaleDto : ItemToAddDto
{
    public bool Extract { get; set; }
    public bool Mortgage { get; set; }
    public bool Repair { get; set; }
    public int CountOfRoom { get; set; }
    public int Floor { get; set; }
    public int CountOfFloor { get; set; }
}