using Microsoft.AspNetCore.Http;

namespace BinaAz.Application.DTOs.Item;

public record ItemDto
{
    public int CityId { get; set; }
    public int Area { get; set; }
    public string? AdditionalInformation { get; set; }
    public int Price { get; set; }
    public int DistrictId { get; set; }
    public int SettlementId { get; set; }
    public string Address { get; set; } = null!;
    public IFormFileCollection Images { get; set; } = null!;
    public string RelevantPerson { get; set; } = null!;
    public bool IsAgent { get; set; }
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
}