namespace BinaAz.Application.DTOs.Item.AddItem;

public record AddGardenHouseSaleDto : ItemToAddDto
{
    public bool Extract { get; set; }
    public bool Mortgage { get; set; }
    public int PlotOfLand { get; set; }
    public bool Repair { get; set; }
    public int CountOfRoom { get; set; }
}