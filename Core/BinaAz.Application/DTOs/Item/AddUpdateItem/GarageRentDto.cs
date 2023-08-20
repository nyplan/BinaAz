using BinaAz.Domain.Enums;

namespace BinaAz.Application.DTOs.Item.AddUpdateItem;

public record GarageRentDto : ItemDto
{
    public DayOrMonth? DayOrMonth { get; set; }
}