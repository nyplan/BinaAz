using BinaAz.Application.DTOs.Item;

namespace BinaAz.Application.Features.Queries.Profile.GetMyItems;

public class GetMyItemsQueryResponse
{
    public List<ItemToListDto> Items { get; set; } = new();
}