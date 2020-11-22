using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RectorsBlogAPI.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public IList<PostCategory> PostCategories { get; set; }
    }
}
