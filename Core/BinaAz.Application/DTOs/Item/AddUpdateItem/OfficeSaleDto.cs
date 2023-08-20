using BinaAz.Domain.Enums;

namespace BinaAz.Application.DTOs.Item.AddUpdateItem;

public record OfficeSaleDto : ItemDto
{
    public TypeOfOffice TypeOfOffice { get; set; }
    public int CountOfRoom { get; set; }
    public bool Repair { get; set; }
    public bool Extract { get; set; }
    public bool Mortgage { get; set; }
}