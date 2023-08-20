namespace BinaAz.Application.DTOs.Item.AddUpdateItem;

public record GardenHouseSaleDto : ItemDto
{
    public bool Extract { get; set; }
    public bool Mortgage { get; set; }
    public int PlotOfLand { get; set; }
    public bool Repair { get; set; }
    public int CountOfRoom { get; set; }
}