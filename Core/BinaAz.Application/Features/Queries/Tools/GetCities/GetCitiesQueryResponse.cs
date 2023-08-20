using BinaAz.Domain.Entities;

namespace BinaAz.Application.Features.Queries.Tools.GetCities;

public class GetCitiesQueryResponse
{
    public List<City> Cities { get; set; } = new();
}