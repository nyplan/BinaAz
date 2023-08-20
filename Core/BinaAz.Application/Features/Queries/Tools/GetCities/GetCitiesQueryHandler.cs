using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities;
using MediatR;

namespace BinaAz.Application.Features.Queries.Tools.GetCities;

public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQueryRequest, GetCitiesQueryResponse>
{
    private readonly IToolRepository<City> _cityRepository;

    public GetCitiesQueryHandler(IToolRepository<City> cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<GetCitiesQueryResponse> Handle(GetCitiesQueryRequest request, CancellationToken cancellationToken)
    {
        return new() { Cities = await _cityRepository.GetAsync() };
    }
}