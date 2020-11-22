using RectorsBlogAPI.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RectorsBlogAPI.Models
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
    }
}
