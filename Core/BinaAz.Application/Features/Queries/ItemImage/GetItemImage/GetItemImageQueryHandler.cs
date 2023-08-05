using BinaAz.Application.Abstractions.Storages;
using MediatR;

namespace BinaAz.Application.Features.Queries.ItemImage.GetItemImage;

public class GetItemImageQueryHandler : IRequestHandler<GetItemImageQueryRequest, GetItemImageQueryResponse>
{
    private readonly ILocalStorageService _storageService;

    public GetItemImageQueryHandler(ILocalStorageService storageService)
    {
        _storageService = storageService;
    }

    public async Task<GetItemImageQueryResponse> Handle(GetItemImageQueryRequest request, CancellationToken cancellationToken)
    {
        if (!_storageService.HasFile($"item-images\\{request.ItemNumber}", request.ImageName))
            throw new Exception("Image does not exist");
        var stream = _storageService.GetImageStream($"item-images\\{request.ItemNumber}", request.ImageName);
        return new() { Stream = stream, ContentType = "image/jpeg" };
    }
}