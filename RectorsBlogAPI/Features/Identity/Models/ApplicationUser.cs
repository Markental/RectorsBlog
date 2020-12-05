using Microsoft.AspNetCore.Identity;
using RectorsBlogAPI.Features.Comments.Models;
using RectorsBlogAPI.Features.Posts.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RectorsBlogAPI.Features.Identity.Models
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
