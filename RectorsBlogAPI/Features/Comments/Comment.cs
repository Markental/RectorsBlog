using RectorsBlogAPI.Features.Identity;
using RectorsBlogAPI.Features.Posts;
using System;
using System.ComponentModel.DataAnnotations;

namespace RectorsBlogAPI.Features.Comments
{
    public class Comment
    {
        public int CommentId { get; set; }
        [Required]
        public string Content { get; set; }

        // *-1
        public int AuthorId { get; set; } 
        public ApplicationUser Author { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
        [Required]
        public DateTime creationDate { get; set; }
    }
}
