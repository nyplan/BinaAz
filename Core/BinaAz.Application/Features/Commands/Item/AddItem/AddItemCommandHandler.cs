using AutoMapper;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BinaAz.Application.Features.Commands.Item.AddItem;

public class AddItemCommandHandler : IRequestHandler<AddItemCommandRequest, AddItemCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Image> _imageRepository;
    private readonly IRepository<Domain.Entities.TPH.Base.Item> _itemRepository;

    public AddItemCommandHandler(IMapper mapper, IRepository<Image> imageRepository, IRepository<Domain.Entities.TPH.Base.Item> itemRepository)
    {
        _mapper = mapper;
        _imageRepository = imageRepository;
        _itemRepository = itemRepository;
    }

    public async Task<AddItemCommandResponse> Handle(AddItemCommandRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Domain.Entities.TPH.Base.Item>(request.Dto); 
        //item.Images = await _imageRepository.GetWhere(x => request.Dto.ImageIds.Contains(x.Id)).ToListAsync(cancellationToken);
        await _itemRepository.AddAsync(item);
        await _itemRepository.SaveAsync();
        return new() { Item = item };
    }
}