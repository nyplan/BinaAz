using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities;
using MediatR;

namespace BinaAz.Application.Features.Queries.Tools.GetSettlements;

public class GetSettlementsQueryHandler : IRequestHandler<GetSettlementsQueryRequest, GetSettlementsQueryResponse>
{
    private readonly IToolRepository<Settlement> _settlementRepository;

    public GetSettlementsQueryHandler(IToolRepository<Settlement> settlementRepository)
    {
        _settlementRepository = settlementRepository;
    }

    public async Task<GetSettlementsQueryResponse> Handle(GetSettlementsQueryRequest request, CancellationToken cancellationToken)
    {
        return new() { Settlements = await _settlementRepository.GetAsync() };
    }
}