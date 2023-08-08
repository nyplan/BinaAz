using BinaAz.Domain.Enums;
using MediatR;

namespace BinaAz.Application.Features.Commands.Subscriptions.VIP;

public class MakeItemVipCommandRequest : IRequest<string>
{
    public int ItemNumber { get; set; }
    public VipType Price { get; set; }
}