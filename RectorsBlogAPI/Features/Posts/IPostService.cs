using RectorsBlogAPI.Features.Posts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RectorsBlogAPI.Features.Posts
{
    public interface IPostService
    {
        Task<int> Create(string title, string body, string summary, int authorId, string posterUrl);

        Task<IEnumerable<PostListingServiceModel>> ByUser(int userId);

        Task<PostDetailsServiceModel> Details(int postId);
    }
}
