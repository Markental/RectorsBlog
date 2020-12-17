using System.ComponentModel.DataAnnotations;

namespace RectorsBlogAPI.Features.Categories.Models
{
    public class CategoryRequestModel
    {
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
