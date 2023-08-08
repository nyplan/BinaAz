using BinaAz.Application.DTOs.User;

namespace BinaAz.Application.Features.Queries.Profile.GetMe;

public class GetMeQueryResponse
{
    public MeDto Me { get; set; } = null!;
}