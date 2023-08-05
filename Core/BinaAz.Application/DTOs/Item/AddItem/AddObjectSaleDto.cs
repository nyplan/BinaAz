namespace BinaAz.Application.DTOs.Item.AddItem;

public record AddObjectSaleDto : ItemToAddDto
{
    public bool Extract { get; set; }
    public bool Mortgage { get; set; }
    public bool Repair { get; set; }
}