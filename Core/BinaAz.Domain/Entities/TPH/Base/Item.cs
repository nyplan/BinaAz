using System.ComponentModel.DataAnnotations.Schema;
using BinaAz.Domain.Entities.Common;
using BinaAz.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace BinaAz.Domain.Entities.TPH.Base;

public class Item : BaseEntity
{
    public int ItemNumber { get; set; }
    
    public int CityId { get; set; }
    public City? City { get; set; }
    public int Area { get; set; }
    public string? AdditionalInformation { get; set; }
    public int Price { get; set; }
    public int DistrictId { get; set; }
    public District? District { get; set; }
    public int SettlementId { get; set; }
    public Settlement? Settlement { get; set; }
    public string Address { get; set; } = null!;
    public List<Image> Images { get; set; } = new();
    public string RelevantPerson { get; set; } = null!;
    public bool IsAgent { get; set; }
    public string Email { get; set; } = null!;
    public int Phone { get; set; }

    public SaleOrRent? SaleOrRent { get; set; }
    public bool? Extract { get; set; }
    public bool? Mortgage { get; set; }
    public DayOrMonth? DayOrMonth { get; set; }
    public bool? Repair { get; set; }
    public int? CountOfRoom { get; set; }
    public int? Floor { get; set; }
    public int? CountOfFloor { get; set; }
}