using BinaAz.Application.Abstractions.Storages;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities;
using BinaAz.Domain.Entities.TPH;
using MediatR;

namespace BinaAz.Application.Features.Commands.ItemImage.UploadItemImage;

public class UploadItemImageCommandHandler : IRequestHandler<UploadItemImageCommandRequest, UploadItemImageCommandResponse>
{
    private readonly IStorageService _storageService;
    private readonly IRepository<Item> _itemRepository;
    private readonly IRepository<Image> _itemImageRepository;

    public UploadItemImageCommandHandler(IStorageService storageService, IRepository<Item> itemRepository, IRepository<Image> itemImageRepository)
    {
        _storageService = storageService;
        _itemRepository = itemRepository;
        _itemImageRepository = itemImageRepository;
    }

    public async Task<UploadItemImageCommandResponse> Handle(UploadItemImageCommandRequest request, CancellationToken cancellationToken)
    {
        List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);

        Item? item = await _itemRepository.GetByIdAsync(request.Id);

        await _itemImageRepository.AddRangeAsync(result.Select(r => new Image
        {
            FileName = r.fileName,
            Path = r.pathOrContainerName,
            Storage = _storageService.StorageName,
            Items = new List<Item>() { item! }
        }).ToList());

        await _itemImageRepository.SaveAsync();

        return new();
    }
}