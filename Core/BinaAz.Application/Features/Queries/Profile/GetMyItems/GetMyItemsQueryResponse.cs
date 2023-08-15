using BinaAz.Application.DTOs.Item;

namespace BinaAz.Application.Features.Queries.Profile.GetMyItems;

public class GetMyItemsQueryResponse
{
    public List<ItemToListDto> Waiting { get; set; } = new();
    public List<ItemToListDto> Active { get; set; } = new();
    public List<ItemToListDto> Expired { get; set; } = new();
    public List<ItemToListDto> Rejected { get; set; } = new();
}