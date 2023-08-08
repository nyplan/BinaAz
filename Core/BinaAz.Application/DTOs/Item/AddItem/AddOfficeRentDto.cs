using BinaAz.Domain.Enums;

namespace BinaAz.Application.DTOs.Item.AddItem;

public record AddOfficeRentDto : ItemToAddDto
{
    public TypeOfOffice TypeOfOffice { get; set; }
    public int CountOfRoom { get; set; }
    public DayOrMonth? DayOrMonth { get; set; }
    public bool Repair { get; set; }
}