using BinaAz.Application.DTOs.Item;

namespace BinaAz.Application.Features.Queries.Items.Grounds;

public class GroundsQueryResponse
{
    public List<ItemToListDto> Items { get; set; } = new();
}