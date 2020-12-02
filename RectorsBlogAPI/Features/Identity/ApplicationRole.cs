using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RectorsBlogAPI.Features.Identity
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole(string name)
        : base(name)
        { }

        public ApplicationRole()
        { }

        [Required]
        public string Description { get; set; }
    }
}
