using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RectorsBlogAPI.Features.Categories.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public IList<PostCategory> PostCategories { get; set; }
    }
}
