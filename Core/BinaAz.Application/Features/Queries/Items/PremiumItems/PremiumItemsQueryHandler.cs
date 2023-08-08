using AutoMapper;
using BinaAz.Application.DTOs.Item;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities.TPH.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BinaAz.Application.Features.Queries.Items.PremiumItems;

public class PremiumItemsQueryHandler : IRequestHandler<PremiumItemsQueryRequest, PremiumItemsQueryResponse>
{
    private readonly IRepository<Item> _itemRepository;
    private readonly IMapper _mapper;

    public PremiumItemsQueryHandler(IRepository<Item> itemRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }

    public async Task<PremiumItemsQueryResponse> Handle(PremiumItemsQueryRequest request, CancellationToken cancellationToken)
    {
        var items = await _itemRepository.Table
            .Include(x => x.Images)
            .Include(x => x.City)
            .Where(x => x.IsPremium == true)
            .Skip(request.Page * request.Size)
            .Take(request.Size)
            .ToListAsync(cancellationToken);

        var premiumItems = _mapper.Map<List<ItemToListDto>>(items);
        return new() { Items = premiumItems };
    }
}