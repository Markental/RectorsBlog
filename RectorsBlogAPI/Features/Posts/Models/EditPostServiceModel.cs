using System.ComponentModel.DataAnnotations;

namespace RectorsBlogAPI.Features.Posts.Models
{
    public class EditPostServiceModel : CreatePostServiceModel
    {
        [Required]
        public int PostId { get; set; }
    }
}
