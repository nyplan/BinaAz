using BinaAz.Application.DTOs.Item;
using BinaAz.Domain.Entities.TPH.Base;

namespace BinaAz.Application.Abstractions.Services;

public interface IItemService
{
    Task<T> MapToItem<T>(ItemDto dto) where T : Item;
    Task<List<ItemToListDto>> MapToItemWithPaging<T>(int page, bool more, bool isRent) where T : Item;
    Task<T> UpdateItem<T>(ItemDto dto, int itemNumber) where T : Item;
}