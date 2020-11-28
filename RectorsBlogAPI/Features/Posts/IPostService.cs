using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RectorsBlogAPI.Features.Posts
{
    public interface IPostService
    {
        Task<int> Create(string title, string body, string summary, int authorId, string posterUrl);
    }
}
