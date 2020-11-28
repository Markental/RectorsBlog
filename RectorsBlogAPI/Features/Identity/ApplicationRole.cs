using Microsoft.AspNetCore.Identity;

namespace RectorsBlogAPI.Features.Identity
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole(string name)
        : base(name)
        { }

        public ApplicationRole()
        { }

        public string Description { get; set; }
    }
}
