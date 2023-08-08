using BinaAz.Application.DTOs.ResidentialComplex;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities;
using BinaAz.Domain.Entities.TPH.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BinaAz.Application.Features.Queries.Items.ResidentialComplexItems;

public class ResidentialComplexItemsQueryHandler : IRequestHandler<ResidentialComplexItemsQueryRequest, ResidentialComplexItemsQueryResponse>
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Item> _itemRepository;

    public ResidentialComplexItemsQueryHandler(IRepository<User> userRepository, IRepository<Item> itemRepository)
    {
        _userRepository = userRepository;
        _itemRepository = itemRepository;
    }

    public async Task<ResidentialComplexItemsQueryResponse> Handle(ResidentialComplexItemsQueryRequest request, CancellationToken cancellationToken)
    {
        var residentials = await _userRepository.Table
            .OfType<Agency>()
            .Where(x => x.IsResidentialComplex)
            .ToListAsync(cancellationToken);

        var complexes = new List<ResidentialComplexToListDto>();
        
        foreach (var residential in residentials)
        {
           var minPrice = await _itemRepository.Table
                .Where(x => x.UserId == residential.Id)
                .MinAsync(x => request.PriceForApartment ? x.Price : x.Price / x.Area, cancellationToken);
           
           complexes.Add(new()
           {
               Address = residential.Address!,
               Name = residential.CompanyName,
               HandOverYear = residential.HandOverYear,
               Image = new() { Path = residential.Image?.Path ?? string.Empty, FileName = residential.Image?.FileName ?? string.Empty},
               MinPrice = minPrice
           });
        }

        return request.More
            ? new() { ResidentialComplexes = complexes.Skip(request.Page * 20).Take(20).ToList() }
            : new() { ResidentialComplexes = complexes.Take(4).ToList() };

    }
}