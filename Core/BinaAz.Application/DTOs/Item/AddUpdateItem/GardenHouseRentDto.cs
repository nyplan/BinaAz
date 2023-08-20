using BinaAz.Domain.Enums;

namespace BinaAz.Application.DTOs.Item.AddUpdateItem;

public record GardenHouseRentDto : ItemDto
{
    public DayOrMonth? DayOrMonth { get; set; }
    public int CountOfRoom { get; set; }
    public int PlotOfLand { get; set; }
    public bool Repair { get; set; }
}