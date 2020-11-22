using RectorsBlogAPI.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RectorsBlogAPI.Models
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

        // *-1
        public int AuthorId { get; set; }
        public ApplicationUser Author { get; set; }

        // 1-*
        public ICollection<Comment> Comments;

        // *-*
        public IList<PostCategory> PostCategories { get; set; }
    }

}
