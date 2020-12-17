using RectorsBlogAPI.Features.Posts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RectorsBlogAPI.Features.Posts
{
    public interface IPostService
    {
        Task<IEnumerable<PostListingServiceModel>> ListAllPosts();
        Task<int> Create(string title, string body, string summary, int authorId, string posterUrl, int[] categoryIds);

        Task<IEnumerable<PostListingServiceModel>> ByUser(int userId);

        Task<PostDetailsServiceModel> Details(int postId);

        Task<bool> Edit(int postId, string posterURL, string title, string body, string summary, int authorId);

        Task<bool> Delete(int postId, int authorId);

        Task<IEnumerable<PostListingServiceModel>> ByCategoryName(string name);
    }
}
