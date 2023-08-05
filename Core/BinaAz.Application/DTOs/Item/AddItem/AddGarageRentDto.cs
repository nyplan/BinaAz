using BinaAz.Domain.Enums;

namespace BinaAz.Application.DTOs.Item.AddItem;

public record AddGarageRentDto : ItemToAddDto
{
    public DayOrMonth? DayOrMonth { get; set; }
}