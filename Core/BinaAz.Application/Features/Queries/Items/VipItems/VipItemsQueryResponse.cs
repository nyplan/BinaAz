using BinaAz.Application.DTOs.Item;

namespace BinaAz.Application.Features.Queries.Items.VipItems;

public class VipItemsQueryResponse
{
    public List<ItemToListDto> Items { get; set; } = new();
}