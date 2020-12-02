using System.ComponentModel.DataAnnotations;

namespace RectorsBlogAPI.Features.Posts
{
    public class CreatePostRequestModel
    {
        [Required]
        public string posterURL { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Body { get; set; }


    }
}
