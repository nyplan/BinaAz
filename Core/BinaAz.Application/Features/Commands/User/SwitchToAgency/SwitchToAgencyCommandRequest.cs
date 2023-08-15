using MediatR;

namespace BinaAz.Application.Features.Commands.User.SwitchToAgency;

public class SwitchToAgencyCommandRequest : IRequest<string>
{
    public string CompanyName { get; set; } = null!;
    public string RelevantPerson { get; set; } = null!;
}