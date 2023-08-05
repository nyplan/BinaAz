namespace BinaAz.Application.DTOs.Item.AddItem;

public record AddGroundSaleDto : ItemToAddDto
{
    public bool Extract { get; set; }
    public bool Mortgage { get; set; }
}