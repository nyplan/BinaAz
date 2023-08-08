using BinaAz.Application.DTOs.Item;

namespace BinaAz.Application.Features.Queries.Items.AgencyItems;

public class AgencyItemsQueryResponse
{
    public List<ItemToListDto> AgencyItems { get; set; } = new();
}