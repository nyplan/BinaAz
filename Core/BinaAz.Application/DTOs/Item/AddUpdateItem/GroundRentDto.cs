using BinaAz.Domain.Enums;

namespace BinaAz.Application.DTOs.Item.AddUpdateItem;

public record GroundRentDto : ItemDto
{
    public DayOrMonth DayOrMonth { get; set; }
}