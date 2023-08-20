namespace BinaAz.Application.DTOs.Item.AddUpdateItem;

public record GarageSaleDto : ItemDto
{
    public bool Extract { get; set; }
    public bool Mortgage { get; set; }
}