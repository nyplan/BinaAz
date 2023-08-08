using BinaAz.Domain.Enums;
using MediatR;

namespace BinaAz.Application.Features.Commands.Subscriptions.Premium;

public class MakeItemPremiumCommandRequest : IRequest<string>
{
    public int ItemNumber { get; set; }
    public PremiumType Price { get; set; }
}