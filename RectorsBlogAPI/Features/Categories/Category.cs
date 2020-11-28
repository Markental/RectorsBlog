using System.Collections.Generic;

namespace RectorsBlogAPI.Features.Categories
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public IList<PostCategory> PostCategories { get; set; }
    }
}
