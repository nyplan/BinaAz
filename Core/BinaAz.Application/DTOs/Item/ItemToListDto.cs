namespace BinaAz.Application.DTOs.Item;

public record ItemToListDto
{
    public List<string> ImageUrls { get; set; } = null!;
    public int Price { get; set; }
    public string City { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int Area { get; set; }
    public int? CountOfRoom { get; set; }
    public int? Floor { get; set; }
    public int? CountOfFloor { get; set; }
    public bool? Extract { get; set; }
    public bool? Mortgage { get; set; }
    public bool? Repair { get; set; }
    public bool? IsVip { get; set; }
    public bool? IsPremium { get; set; }
    public DateTime CreatedAt { get; set; }
}