using BinaAz.Application.DTOs.Item;

namespace BinaAz.Application.Features.Queries.Items.GardenHouses;

public class GardenHousesQueryResponse
{
    public List<ItemToListDto> Items { get; set; } = new();
}