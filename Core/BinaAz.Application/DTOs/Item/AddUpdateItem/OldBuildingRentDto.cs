using BinaAz.Domain.Enums;

namespace BinaAz.Application.DTOs.Item.AddUpdateItem;

public record OldBuildingRentDto : ItemDto
{
    public DayOrMonth? DayOrMonth { get; set; }
    public bool Repair { get; set; }
    public int CountOfRoom { get; set; }
    public int Floor { get; set; }
    public int CountOfFloor { get; set; }
}