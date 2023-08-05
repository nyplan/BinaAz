using BinaAz.Domain.Enums;

namespace BinaAz.Application.DTOs.Item.AddItem;

public record AddGardenHouseRentDto : ItemToAddDto
{
    public DayOrMonth? DayOrMonth { get; set; }
    public int CountOfRoom { get; set; }
    public int PlotOfLand { get; set; }
    public bool Repair { get; set; }
}