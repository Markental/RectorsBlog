using RectorsBlogAPI.Features.Categories.Models;
using RectorsBlogAPI.Features.Comments.Models;
using RectorsBlogAPI.Features.Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RectorsBlogAPI.Features.Posts.Models
{
    public class Post
    {
        public int PostId { get; set; }
        [Required]
        public string posterURL { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public DateTime creationDate { get; set; }

        // *-1
        public int AuthorId { get; set; }
        public ApplicationUser Author { get; set; }

        // 1-*
        public IList<Comment> Comments { get; set; }

        // *-*
        public IList<PostCategory> PostCategories { get; set; }
    }

}
