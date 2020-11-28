using RectorsBlogAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RectorsBlogAPI.Features.Posts
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext data;

        public PostService(ApplicationDbContext context)
        {
            data = context;
        }

        public async Task<int> Create(string title, string body, string summary, int authorId, string posterUrl)
        {
            var post = new Post()
            {
                Title = title,
                Body = body,
                Summary = summary,
                AuthorId = authorId,
                posterURL = posterUrl,
                creationDate = DateTime.Now
            };

            data.Add(post);

            await data.SaveChangesAsync();

            return post.PostId;
        }
    }
}
