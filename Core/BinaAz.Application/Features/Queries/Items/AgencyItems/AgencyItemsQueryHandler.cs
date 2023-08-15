using AutoMapper;
using BinaAz.Application.DTOs.Item;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities;
using BinaAz.Domain.Entities.TPH.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BinaAz.Application.Features.Queries.Items.AgencyItems;

public class AgencyItemsQueryHandler : IRequestHandler<AgencyItemsQueryRequest, AgencyItemsQueryResponse>
{
    private readonly IRepository<Item> _itemRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public AgencyItemsQueryHandler(IRepository<Item> itemRepository, IRepository<User> userRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AgencyItemsQueryResponse> Handle(AgencyItemsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var agencies = await _userRepository.Table
            .Where(x => x.IsAgency == true)
            .Include(x => x.Items)
            .Select(x => x.Id)
            .ToListAsync(cancellationToken);

        var agencyItems = request.More
            ? await _itemRepository.Table
                .Include(x => x.City)
                .Where(x => agencies.Contains(x.Id))
                .Skip(request.Page * 20)
                .Take(20)
                .ToListAsync(cancellationToken)
            : await _itemRepository.Table
                .Include(x => x.City)
                .Where(x => agencies.Contains(x.Id))
                .Skip(request.Page * 4)
                .Take(4)
                .ToListAsync(cancellationToken);

        var items = _mapper.Map<List<ItemToListDto>>(agencyItems);
        return new() { AgencyItems = items };
    }
}