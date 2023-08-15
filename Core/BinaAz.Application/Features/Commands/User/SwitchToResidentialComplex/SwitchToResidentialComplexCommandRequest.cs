using MediatR;

namespace BinaAz.Application.Features.Commands.User.SwitchToResidentialComplex;

public class SwitchToResidentialComplexCommandRequest : IRequest<string>
{
    public string CompanyName { get; set; } = null!;
    public string RelevantPerson { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int HandOverYear { get; set; }
}