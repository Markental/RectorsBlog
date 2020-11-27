using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RectorsBlogAPI.Models
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
