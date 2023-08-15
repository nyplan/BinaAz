using AutoMapper;
using BinaAz.Application.DTOs.Item;
using BinaAz.Application.Exceptions;
using BinaAz.Application.Extensions;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities.TPH.Base;
using BinaAz.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BinaAz.Application.Features.Queries.Profile.GetMyItems;

public class GetMyItemsQueryHandler : IRequestHandler<GetMyItemsQueryRequest, GetMyItemsQueryResponse>
{
    private readonly IRepository<Item> _itemRepository;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IMapper _mapper;

    public GetMyItemsQueryHandler(IRepository<Item> itemRepository, IHttpContextAccessor contextAccessor, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _contextAccessor = contextAccessor;
        _mapper = mapper;
    }

    public async Task<GetMyItemsQueryResponse> Handle(GetMyItemsQueryRequest request, CancellationToken cancellationToken)
    {
        if (_contextAccessor.HttpContext is null)
            throw new AuthenticationException();

        var waiting = await _itemRepository
            .Table
            .Where(x => x.UserId == _contextAccessor.HttpContext.User.GetId())
            .Where(x => x.Status == ItemStatus.Waiting)
            .ToListAsync(cancellationToken);
        
        var active = await _itemRepository
            .Table
            .Where(x => x.UserId == _contextAccessor.HttpContext.User.GetId())
            .Where(x => x.Status == ItemStatus.Active)
            .ToListAsync(cancellationToken);
        
        var expired = await _itemRepository
            .Table
            .Where(x => x.UserId == _contextAccessor.HttpContext.User.GetId())
            .Where(x => x.Status == ItemStatus.Expired)
            .ToListAsync(cancellationToken);
        
        var rejected = await _itemRepository
            .Table
            .Where(x => x.UserId == _contextAccessor.HttpContext.User.GetId())
            .Where(x => x.Status == ItemStatus.Rejected)
            .ToListAsync(cancellationToken);

        return new()
        {
            Waiting = _mapper.Map<List<ItemToListDto>>(waiting),
            Active = _mapper.Map<List<ItemToListDto>>(active),
            Expired = _mapper.Map<List<ItemToListDto>>(expired),
            Rejected = _mapper.Map<List<ItemToListDto>>(rejected)
        };
    }
}