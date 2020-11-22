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

        public ICollection<Post> BlogPosts { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
