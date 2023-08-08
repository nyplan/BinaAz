using AutoMapper;
using BinaAz.Application.DTOs.Item;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities.TPH.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BinaAz.Application.Features.Queries.Items.VipItems;

public class VipItemsQueryHandler : IRequestHandler<VipItemsQueryRequest, VipItemsQueryResponse>
{
    private readonly IRepository<Item> _itemRepository;
    private readonly IMapper _mapper;

    public VipItemsQueryHandler(IRepository<Item> itemRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }

    public async Task<VipItemsQueryResponse> Handle(VipItemsQueryRequest request, CancellationToken cancellationToken)
    {
        var vipItems = request.More
            ? await _itemRepository
                .GetWhere(x => x.IsVip == true)
                .Skip(request.Page * 20)
                .Take(20)
                .ToListAsync(cancellationToken)
            : await _itemRepository
                .GetWhere(x => x.IsVip == true)
                .Skip(request.Page * 8)
                .Take(8)
                .ToListAsync(cancellationToken);

        var items = _mapper.Map<List<ItemToListDto>>(vipItems);

        return new() { Items = items };
    }
}