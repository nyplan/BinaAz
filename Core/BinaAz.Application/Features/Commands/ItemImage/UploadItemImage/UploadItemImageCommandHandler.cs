using BinaAz.Application.Abstractions.Storages;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities;
using MediatR;

namespace BinaAz.Application.Features.Commands.ItemImage.UploadItemImage;

public class UploadItemImageCommandHandler : IRequestHandler<UploadItemImageCommandRequest, UploadItemImageCommandResponse>
{
    private readonly ILocalStorageService _storageService;
    private readonly IRepository<Image> _itemImageRepository;

    public UploadItemImageCommandHandler(ILocalStorageService storageService, IRepository<Image> itemImageRepository)
    {
        _storageService = storageService;
        _itemImageRepository = itemImageRepository;
    }

    public async Task<UploadItemImageCommandResponse> Handle(UploadItemImageCommandRequest request, CancellationToken cancellationToken)
    {
        List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("item-images", request.Files);

        List<Image> images = new List<Image>();
        foreach (var file in result)
        {
            images.Add(new()
            {
                FileName = file.fileName,
                Path = file.pathOrContainerName,
            });
        }
        await _itemImageRepository.AddRangeAsync(images);
        await _itemImageRepository.SaveAsync();

        var imageIds = new List<Guid>();

        foreach (var image in images)
        {
            var file = await _itemImageRepository.GetSingleAsync(x =>
                x.FileName == image.FileName && x.Path == image.Path);
            imageIds.Add(file.Id);
        }
        return new() { ImageIds = imageIds };
    }
}