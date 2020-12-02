using Microsoft.AspNetCore.Identity;
using RectorsBlogAPI.Features.Comments;
using RectorsBlogAPI.Features.Posts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RectorsBlogAPI.Features.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
        }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public IList<Post> Posts { get; set; }

        public IList<Comment> Comments { get; set; }
    }
}
