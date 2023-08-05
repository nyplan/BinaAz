using MediatR;
using Microsoft.AspNetCore.Http;

namespace BinaAz.Application.Features.Commands.ItemImage.UploadItemImage;

public class UploadItemImageCommandRequest : IRequest<UploadItemImageCommandResponse>
{
    public IFormFileCollection? Files { get; set; }
}