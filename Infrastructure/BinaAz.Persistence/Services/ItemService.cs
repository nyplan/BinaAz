using AutoMapper;
using BinaAz.Application.Abstractions.Services;
using BinaAz.Application.DTOs.Item;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities.TPH.Base;
using BinaAz.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace BinaAz.Persistence.Services;

public class ItemService : IItemService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Item> _itemRepository;
    public ItemService(IMapper mapper, IRepository<Item> itemRepository)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
    }

    public async Task<T> MapToItem<T>(ItemDto dto) where T : Item
    {
        var item = _mapper.Map<T>(dto);
        item.SaleOrRent = item.DayOrMonth is null ? SaleOrRent.Sale : SaleOrRent.Rent;
        item.ItemNumber = await GenerateNumber();
        return item;
    }

    public async Task<List<ItemToListDto>> MapToItemWithPaging<T>(int page, bool more, bool isRent) where T : Item
    {
        var items = more
            ? await _itemRepository.Table
                .OfType<T>()
                .Include(x => x.City)
                .Where(x => isRent ? x.SaleOrRent == SaleOrRent.Rent : x.SaleOrRent == SaleOrRent.Sale)
                .Skip(page * 20)
                .Take(20)
                .ToListAsync()
            : await _itemRepository.Table
                .OfType<T>()
                .Include(x => x.City)
                .Where(x => isRent ? x.SaleOrRent == SaleOrRent.Rent : x.SaleOrRent == SaleOrRent.Sale)
                .Skip(page * 4)
                .Take(4)
                .ToListAsync();

        return _mapper.Map<List<ItemToListDto>>(items);
    }

    public Task<T> UpdateItem<T>(ItemDto dto, int itemNumber) where T : Item
    {
        var item = _mapper.Map<T>(dto);
        item.SaleOrRent = item.DayOrMonth is null ? SaleOrRent.Sale : SaleOrRent.Rent;
        item.ItemNumber = itemNumber;
        return Task.FromResult(item);
    }
    
    private async Task<int> GenerateNumber()
    {
        Random random = new Random();
        var number = random.Next(100000000, 999999999);
        if (await _itemRepository.Table.AnyAsync(x => x.ItemNumber == number))
            await GenerateNumber();
        return number;
    }
}