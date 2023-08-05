using BinaAz.Domain.Enums;

namespace BinaAz.Application.DTOs.Item.AddItem;

public record AddGroundRentDto : ItemToAddDto
{
    public DayOrMonth DayOrMonth { get; set; }
}