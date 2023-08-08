using BinaAz.Application.DTOs.Item;

namespace BinaAz.Application.Features.Queries.Items.Offices;

public class OfficesQueryResponse
{
    public List<ItemToListDto> Items { get; set; } = new();
}