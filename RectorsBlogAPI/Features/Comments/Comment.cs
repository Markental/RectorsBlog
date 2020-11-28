using RectorsBlogAPI.Features.Identity;
using RectorsBlogAPI.Features.Posts;
using System;

namespace RectorsBlogAPI.Features.Comments
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }

        // *-1
        public int AuthorId { get; set; } 
        public ApplicationUser Author { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
        public DateTime creationDate { get; set; }
    }
}
