using RectorsBlogAPI.Features.Posts.Models;

namespace RectorsBlogAPI.Features.Categories.Models
{
    public class PostCategory
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
