using MediatR;

namespace BinaAz.Application.Features.Queries.Items.ResidentialComplexItems;

public class ResidentialComplexItemsQueryRequest : IRequest<ResidentialComplexItemsQueryResponse>
{
    public int Page { get; set; }
    public bool More { get; set; }
    public bool PriceForApartment { get; set; }
}