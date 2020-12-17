using System;

namespace RectorsBlogAPI.Features.Comments.Models
{
    public class CommentResponseModel
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int PostId { get; set; }
        public DateTime creationDate { get; set; }
    }
}
