using BinaAz.Domain.Entities;

namespace BinaAz.Application.Features.Queries.Tools.GetSettlements;

public class GetSettlementsQueryResponse
{
    public List<Settlement> Settlements { get; set; } = new();
}