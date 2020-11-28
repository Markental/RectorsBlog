using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RectorsBlogAPI.Data;
using RectorsBlogAPI.Infrastructure;

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
        public async Task<ActionResult<int>> Create(CreatePostRequestModel model)
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


    }
}