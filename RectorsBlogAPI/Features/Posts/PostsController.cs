using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RectorsBlogAPI.Features.Posts.Models;
using RectorsBlogAPI.Infrastructure.Extensions;

namespace RectorsBlogAPI.Features.Posts
{
    public class PostsController : ApiController
    {
        private readonly IPostService postService;

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        [Authorize]
        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<int>> Create(CreatePostServiceModel model)
        {
            var userId = User.GetId();

            var id = await postService.Create(
                model.Title,
                model.Body,
                model.Summary,
                userId,
                model.posterURL);

            return Created(nameof(this.Create), id);
        }

        [Authorize]
        [HttpGet]
        [Route(nameof(Mine))]
        public async Task<IEnumerable<PostListingServiceModel>> Mine()
            => await postService.ByUser(User.GetId());

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PostDetailsServiceModel>> Details(int postId) 
            => await postService.Details(postId);
        
        

    }
}