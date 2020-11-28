using System.Linq;
using System.Security.Claims;

namespace RectorsBlogAPI.Infrastructure
{
    public static class IdentityExtensions
    {
        public static int GetId(this ClaimsPrincipal user)
            => int.Parse(user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
    }
}
