using Microsoft.AspNetCore.Identity;
using RectorsBlogAPI.Features.Comments;
using RectorsBlogAPI.Features.Posts;
using System.Collections.Generic;

namespace RectorsBlogAPI.Features.Identity
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
