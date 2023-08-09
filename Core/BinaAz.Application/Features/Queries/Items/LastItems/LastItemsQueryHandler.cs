using AutoMapper;
using BinaAz.Application.DTOs.Item;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities.TPH.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BinaAz.Application.Features.Queries.Items.LastItems;

public class LastItemsQueryHandler : IRequestHandler<LastItemsQueryRequest, LastItemsQueryResponse>
{
    private readonly IRepository<Item> _itemRepository;
    private readonly IMapper _mapper;

    public LastItemsQueryHandler(IRepository<Item> itemRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }

    public async Task<LastItemsQueryResponse> Handle(LastItemsQueryRequest request, CancellationToken cancellationToken)
    {
        var lastItems = request.More
            ? await _itemRepository.Table
                .Include(x => x.City)
                .OrderByDescending(x => x.CreatedAt)
                .Skip(request.Page * 20)
                .Take(20)
                .ToListAsync(cancellationToken)
            : await _itemRepository.Table
                .Include(x => x.City)
                .OrderByDescending(x => x.CreatedAt)
                .Take(8)
                .ToListAsync(cancellationToken);
        var items = _mapper.Map<List<ItemToListDto>>(lastItems);
        return new() { Items = items };
    }
}