using BinaAz.Domain.Enums;

namespace BinaAz.Application.DTOs.Item.AddItem;

public record AddObjectRentDto : ItemToAddDto
{
    public DayOrMonth? DayOrMonth { get; set; }
    public bool Repair { get; set; }
}