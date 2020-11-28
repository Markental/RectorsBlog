using System.ComponentModel.DataAnnotations;

namespace RectorsBlogAPI.Features.Posts
{
    public class CreatePostRequestModel
    {
        public string posterURL { get; set; }
        [Required]
        public string Title { get; set; }
        public string Summary { get; set; }
        [Required]
        public string Body { get; set; }


    }
}
