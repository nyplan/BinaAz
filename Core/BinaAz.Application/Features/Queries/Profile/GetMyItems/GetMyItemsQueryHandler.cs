using AutoMapper;
using BinaAz.Application.DTOs.Item;
using BinaAz.Application.Exceptions;
using BinaAz.Application.Extensions;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities.TPH.Base;
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

        var items = await _itemRepository
            .Table
            .Where(x => x.UserId == _contextAccessor.HttpContext.User.GetId())
            .ToListAsync(cancellationToken);
        
        return new()
        {
            Items = _mapper.Map<List<ItemToListDto>>(items)
        };
    }
}