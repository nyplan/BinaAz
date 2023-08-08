using BinaAz.Application.DTOs.Item;

namespace BinaAz.Application.Features.Queries.Items.Garages;

public class GaragesQueryResponse
{
    public List<ItemToListDto> Items { get; set; } = new();
}