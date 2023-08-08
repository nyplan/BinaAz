using BinaAz.Application.DTOs.Item;
using BinaAz.Domain.Enums;
using MediatR;

namespace BinaAz.Application.Features.Queries.Items.GeneralSearch;

public class GeneralSearchCommandRequest : IRequest<List<ItemToListDto>>
{
    public SaleOrRent SaleOrRent { get; set; }
    public ApartmentType? ApartmentType { get; set; } = null;
    public CountOfRoom? CountOfRoom { get; set; } = null;
    public int? MinPrice { get; set; } = null;
    public int? MaxPrice { get; set; } = null;
    public int? MinArea { get; set; } = null;
    public int? MaxArea { get; set; } = null;
    public int? MinFloor { get; set; } = null;
    public int? MaxFloor { get; set; } = null;
    public int? CityId { get; set; } = null;
    public bool? Repair { get; set; } = null;
    public bool? MustNotBeFirst { get; set; } = null;
    public bool? MustNotBeTop { get; set; } = null;
    public bool? OnlyTop { get; set; } = null;
    public int? SettlementId { get; set; } = null;
    public bool? Mortgage { get; set; } = null;
    public bool? Extract { get; set; } = null;
    public DayOrMonth? DayOrMonth { get; set; } = null;
    
    public int? MinLandArea { get; set; } = null;
    public int? MaxLandArea { get; set; } = null;
    public TypeOfOffice? TypeOfOffice { get; set; } = null!;

    public int? ItemNumber { get; set; } = null;
}

public record CountOfRoom
{
    public bool One { get; set; }
    public bool Two { get; set; }
    public bool Three { get; set; }
    public bool Four { get; set; }
    public bool FiveAndMore { get; set; }
}