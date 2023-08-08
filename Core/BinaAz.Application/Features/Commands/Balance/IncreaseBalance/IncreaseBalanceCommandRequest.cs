using MediatR;

namespace BinaAz.Application.Features.Commands.Balance.IncreaseBalance;

public class IncreaseBalanceCommandRequest : IRequest<IncreaseBalanceCommandResponse>
{
    public double Amount { get; set; }
    public string CardNumber { get; set; } = null!;
    public string Cvv { get; set; } = null!;
    public string ExpireDate { get; set; } = null!;
}