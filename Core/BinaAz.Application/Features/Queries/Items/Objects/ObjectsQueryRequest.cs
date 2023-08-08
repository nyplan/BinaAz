using MediatR;

namespace BinaAz.Application.Features.Queries.Items.Objects;

public class ObjectsQueryRequest : IRequest<ObjectsQueryResponse>
{
    public int Page { get; set; }
    public bool More { get; set; }
    public bool IsRent { get; set; }
}