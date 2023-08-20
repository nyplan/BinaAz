using BinaAz.Domain.Enums;

namespace BinaAz.Application.DTOs.Item.AddUpdateItem;

public record ObjectRentDto : ItemDto
{
    public DayOrMonth? DayOrMonth { get; set; }
    public bool Repair { get; set; }
}