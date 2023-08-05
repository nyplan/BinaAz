using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace BinaAz.Application.Extensions;

public static class ClaimsPrincipalExtensions
{
    private static readonly IHttpContextAccessor ContextAccessor = new HttpContextAccessor();
    public static Guid GetId(this ClaimsPrincipal principal)
    {
        return Guid.Parse(principal.FindFirst(ClaimTypes.Sid)!.Value);
    }
    
    public static Guid GetUsername(this ClaimsPrincipal principal)
    {
        return Guid.Parse(principal.FindFirst(ClaimTypes.Name)!.Value);
    }
}