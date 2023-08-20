using BinaAz.Application.Exceptions;
using BinaAz.Application.Extensions;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BinaAz.Application.Features.Queries.Profile.GetMe;

public class GetMeQueryHandler : IRequestHandler<GetMeQueryRequest, GetMeQueryResponse>
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IRepository<User> _userRepository;
    
    public GetMeQueryHandler(IHttpContextAccessor contextAccessor, IRepository<User> userRepository)
    {
        _contextAccessor = contextAccessor;
        _userRepository = userRepository;
    }

    public async Task<GetMeQueryResponse> Handle(GetMeQueryRequest request, CancellationToken cancellationToken)
    {
        var meId = _contextAccessor.HttpContext?.User.GetId();
        var user = await _userRepository.Table.FirstOrDefaultAsync(x => x.Id == meId, cancellationToken);

        if (user is null)
            throw new UserNotFoundException();
        
        return new()
        {
            Me = new()
            {
                Email = user.Email,
                Phone = user.Phone,
                CompanyName = user.CompanyName,
                RelevantPerson = user.RelevantPerson,
                Balance = user.Balance,
                ImageUrl = user.ImageUrl?.Replace("\\", "/")
            }
        };
    }
}