using BinaAz.Domain.Entities;

namespace BinaAz.Application.Features.Queries.Tools.GetDistricts;

public class GetDistrictsQueryResponse
{
    public List<District> Districts { get; set; } = new();
}