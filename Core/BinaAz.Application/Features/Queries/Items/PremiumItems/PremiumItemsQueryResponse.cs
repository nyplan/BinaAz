using BinaAz.Application.DTOs.Item;

namespace BinaAz.Application.Features.Queries.Items.PremiumItems;

public class PremiumItemsQueryResponse
{
    public List<ItemToListDto> Items { get; set; } = new();
}