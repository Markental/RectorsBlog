using Microsoft.EntityFrameworkCore;
using RectorsBlogAPI.Data;
using RectorsBlogAPI.Features.Posts.Models;
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
        public async Task<IEnumerable<PostListingServiceModel>> ByUser(int userId)
            => await data
                .Posts
                .Where(p => p.AuthorId == userId)
                .Select(p => new PostListingServiceModel
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    Summary = p.Summary,
                    creationDate = p.creationDate,
                    posterURL = p.posterURL
                }).ToListAsync();

        public async Task<PostDetailsServiceModel> Details(int postId)
            => await data
                .Posts
                .Where(p => p.PostId == postId)
                .Select(p => new PostDetailsServiceModel 
                {
                    PostId = p.PostId,
                    AuthorId = p.AuthorId,
                    UserName = p.Author.UserName,
                    posterURL = p.posterURL,
                    Summary = p.Summary,
                    Body = p.Body,
                    creationDate = p.creationDate
                })
                .FirstOrDefaultAsync();
    }
}
