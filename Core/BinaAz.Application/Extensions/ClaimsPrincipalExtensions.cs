using System.Security.Claims;

namespace BinaAz.Application.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetId(this ClaimsPrincipal principal)
    {
        return Guid.Parse(principal.FindFirst(ClaimTypes.Sid)!.Value);
    }
    
    public static Guid GetUsername(this ClaimsPrincipal principal)
    {
        return Guid.Parse(principal.FindFirst(ClaimTypes.Name)!.Value);
    }
}