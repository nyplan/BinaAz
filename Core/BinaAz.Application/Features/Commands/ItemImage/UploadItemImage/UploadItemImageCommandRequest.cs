using MediatR;
using Microsoft.AspNetCore.Http;

namespace BinaAz.Application.Features.Commands.ItemImage.UploadItemImage;

public class UploadItemImageCommandRequest : IRequest<UploadItemImageCommandResponse>
{
    public string Id { get; set; }
    public IFormFileCollection? Files { get; set; }
}