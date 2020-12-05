using System;
using System.ComponentModel.DataAnnotations;

namespace RectorsBlogAPI.Features.Posts.Models
{
    public class PostDetailsServiceModel
    {
        [Required]
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
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public string UserName { get; set; }

        // maybe have comments and categories here?

    }
}
