using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities;
using MediatR;

namespace BinaAz.Application.Features.Queries.Tools.GetDistricts;

public class GetDistrictsQueryHandler : IRequestHandler<GetDistrictsQueryRequest, GetDistrictsQueryResponse>
{
    private readonly IToolRepository<District> _districtRepository;

    public GetDistrictsQueryHandler(IToolRepository<District> districtRepository)
    {
        _districtRepository = districtRepository;
    }

    public async Task<GetDistrictsQueryResponse> Handle(GetDistrictsQueryRequest request, CancellationToken cancellationToken)
    {
        return new() { Districts = await _districtRepository.GetAsync() };
    }
}