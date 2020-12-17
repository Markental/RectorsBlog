using Microsoft.EntityFrameworkCore;
using RectorsBlogAPI.Data;
using RectorsBlogAPI.Features.Categories.Models;
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

        public async Task<int> Create(string title, string body, string summary, int authorId, string posterUrl, int[] categoryIds)
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

            if (categoryIds != null && categoryIds.Length != 0)
            {
                var selectedCategories = await data.Categories.Where(t => categoryIds.Contains(t.CategoryId)).ToListAsync();
                foreach (var category in selectedCategories)
                {
                    data
                        .Add(new PostCategory
                        {
                            CategoryId = category.CategoryId,
                            PostId = post.PostId
                        });
                }
            }
            await data.SaveChangesAsync();

            return post.PostId;
        }

        public async Task<IEnumerable<PostListingServiceModel>> ListAllPosts()
             => await data
                .Posts
                .Select(p => new PostListingServiceModel 
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    Summary = p.Summary,
                    creationDate = p.creationDate,
                    posterURL = p.posterURL,
                    UserName = p.Author.UserName,
                    UserId = p.AuthorId
                })
                .ToListAsync();

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
                    posterURL = p.posterURL,
                    UserName = p.Author.UserName,
                    UserId = p.AuthorId
                }).ToListAsync();

        public async Task<PostDetailsServiceModel> Details(int postId)
            => await data
                .Posts
                .Where(p => p.PostId == postId)
                .Select(p => new PostDetailsServiceModel 
                {
                    PostId = p.PostId,
                    UserId = p.AuthorId,
                    UserName = p.Author.UserName,
                    posterURL = p.posterURL,
                    Summary = p.Summary,
                    Body = p.Body,
                    Title = p.Title,
                    creationDate = p.creationDate
                })
                .FirstOrDefaultAsync();

        public async Task<bool> Edit(int postId, string posterURL, string title, string body, string summary, int authorId) 
        {
            var post = await ByIdAndByUserId(postId, authorId);

            if (post == null) 
            {
                return false;
            }

            post.posterURL = posterURL;
            post.Title = title;
            post.Body = body;
            post.Summary = summary;

            await data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int postId, int authorId)
        {
            var post = await ByIdAndByUserId(postId, authorId);

            if (post == null) 
            {
                return false;
            }

            data.Posts.Remove(post);

            await data.SaveChangesAsync();

            return true;
        }

        private async Task<Post> ByIdAndByUserId(int postId, int userId) 
            => await data.Posts.Where(p => p.PostId == postId && p.AuthorId == userId).FirstOrDefaultAsync();

        public async Task<IEnumerable<PostListingServiceModel>> ByCategoryName(string name)
        {
            var posts = data.Posts.Include(e => e.PostCategories);

            // posts filtered by category name
            var filtered = await posts
                .Where(p => p.PostCategories
                .Any(c => c.Category.CategoryName == name))
                .Select(p => new PostListingServiceModel 
                { 
                    creationDate = p.creationDate,
                    posterURL = p.posterURL,
                    Summary = p.Summary,
                    PostId = p.PostId,
                    Title = p.Title,
                    UserId = p.Author.Id,
                    UserName = p.Author.UserName
                })
                .ToListAsync();

            return filtered;

        }
        
    }
}
