using MediatR;

namespace BinaAz.Application.Features.Queries.ItemImage.GetItemImage;

public class GetItemImageQueryRequest : IRequest<GetItemImageQueryResponse>
{
    public string ItemNumber { get; set; }
    public string ImageName { get; set; }
}