namespace BinaAz.Application.DTOs.Item.AddUpdateItem;

public record GroundSaleDto : ItemDto
{
    public bool Extract { get; set; }
    public bool Mortgage { get; set; }
}