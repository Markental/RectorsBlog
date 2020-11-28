using RectorsBlogAPI.Features.Categories;
using RectorsBlogAPI.Features.Comments;
using RectorsBlogAPI.Features.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RectorsBlogAPI.Features.Posts
{
    public class Post
    {
        public int PostId { get; set; }
        
        public string posterURL { get; set; }
        [Required]
        public string Title { get; set; }
        public string Summary { get; set; }
        [Required]
        public string Body { get; set; }
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
