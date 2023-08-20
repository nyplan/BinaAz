namespace BinaAz.Application.DTOs.Item.AddUpdateItem;

public record ObjectSaleDto : ItemDto
{
    public bool Extract { get; set; }
    public bool Mortgage { get; set; }
    public bool Repair { get; set; }
}