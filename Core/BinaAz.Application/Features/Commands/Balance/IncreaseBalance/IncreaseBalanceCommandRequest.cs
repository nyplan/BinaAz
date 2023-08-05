using System.Runtime.InteropServices.JavaScript;
using MediatR;

namespace BinaAz.Application.Features.Commands.Balance.IncreaseBalance;

public class IncreaseBalanceCommandRequest : IRequest<IncreaseBalanceCommandResponse>
{
    public double Amount { get; set; }
    public int CardNumber { get; set; }
    public int Cvv { get; set; }
    public int ExpireYear { get; set; }
    public int ExpireMonth { get; set; }
}