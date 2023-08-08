using BinaAz.Application.DTOs.Item;

namespace BinaAz.Application.Features.Queries.Items.Objects;

public class ObjectsQueryResponse
{
    public List<ItemToListDto> Items { get; set; } = new();
}