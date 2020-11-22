using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RectorsBlogAPI.Models.Identity
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
