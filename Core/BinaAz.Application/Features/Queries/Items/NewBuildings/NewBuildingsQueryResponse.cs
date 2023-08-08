using BinaAz.Application.DTOs.Item;

namespace BinaAz.Application.Features.Queries.Items.NewBuildings;

public class NewBuildingsQueryResponse
{
    public List<ItemToListDto> Items { get; set; } = new();
}