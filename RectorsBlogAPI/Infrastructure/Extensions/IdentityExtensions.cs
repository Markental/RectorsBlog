using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RectorsBlogAPI.Infrastructure.Extensions
{
    public static class IdentityExtensions
    {
        public static int GetId(this ClaimsPrincipal user)
            => int.Parse(user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
    }
}
