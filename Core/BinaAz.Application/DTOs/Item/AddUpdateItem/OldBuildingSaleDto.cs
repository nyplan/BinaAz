namespace BinaAz.Application.DTOs.Item.AddUpdateItem;

public record OldBuildingSaleDto : ItemDto
{
    public bool Extract { get; set; }
    public bool Mortgage { get; set; }
    public bool Repair { get; set; }
    public int CountOfRoom { get; set; }
    public int Floor { get; set; }
    public int CountOfFloor { get; set; }
}