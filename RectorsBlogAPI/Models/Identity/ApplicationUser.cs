using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RectorsBlogAPI.Models.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
        }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<Post> Posts { get; set; }

        public IList<Comment> Comments { get; set; }
    }
}
