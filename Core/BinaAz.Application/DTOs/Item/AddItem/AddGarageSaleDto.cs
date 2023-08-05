namespace BinaAz.Application.DTOs.Item.AddItem;

public record AddGarageSaleDto : ItemToAddDto
{
    public bool Extract { get; set; }
    public bool Mortgage { get; set; }
}