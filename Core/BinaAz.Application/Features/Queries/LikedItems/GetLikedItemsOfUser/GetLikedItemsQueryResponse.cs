using BinaAz.Application.DTOs.Item;

namespace BinaAz.Application.Features.Queries.LikedItems.GetLikedItemsOfUser;

public class GetLikedItemsQueryResponse
{
    public List<ItemToListDto> LikedItems { get; set; } = new();
}