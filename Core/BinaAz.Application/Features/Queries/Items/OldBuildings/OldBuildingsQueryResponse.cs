using BinaAz.Application.DTOs.Item;

namespace BinaAz.Application.Features.Queries.Items.OldBuildings;

public class OldBuildingsQueryResponse
{
    public List<ItemToListDto> Items { get; set; } = new();
}