using BinaAz.Application.DTOs.Item;

namespace BinaAz.Application.Features.Queries.Items.LastItems;

public class LastItemsQueryResponse
{
    public List<ItemToListDto> Items { get; set; } = new();
}