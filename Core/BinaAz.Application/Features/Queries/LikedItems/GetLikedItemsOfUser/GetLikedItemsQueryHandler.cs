using AutoMapper;
using BinaAz.Application.DTOs.Item;
using BinaAz.Application.Exceptions;
using BinaAz.Application.Extensions;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using AuthenticationException = System.Security.Authentication.AuthenticationException;

namespace BinaAz.Application.Features.Queries.LikedItems.GetLikedItemsOfUser;

public class GetLikedItemsQueryHandler : IRequestHandler<GetLikedItemsQueryRequest, GetLikedItemsQueryResponse>
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public GetLikedItemsQueryHandler(IHttpContextAccessor contextAccessor, IRepository<User> userRepository, IMapper mapper)
    {
        _contextAccessor = contextAccessor;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetLikedItemsQueryResponse> Handle(GetLikedItemsQueryRequest request, CancellationToken cancellationToken)
    {
        if (_contextAccessor.HttpContext is null)
            throw new AuthenticationException();

        var user = await _userRepository.GetSingleAsync(x => x.Id == _contextAccessor.HttpContext.User.GetId());
        if (user is null)
            throw new UserNotFoundException();

        return new() { LikedItems = _mapper.Map<List<ItemToListDto>>(user.Liked) };

    }
}