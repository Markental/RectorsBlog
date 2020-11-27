using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RectorsBlogAPI.Data;
using RectorsBlogAPI.Infrastructure.Extensions;
using RectorsBlogAPI.Models;

namespace RectorsBlogAPI.Controllers
{
    public class PostsController : ApiController
    {
        private readonly ApplicationDbContext data;

        public PostsController(ApplicationDbContext context)
        {
            data = context;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePostRequestModel model)
        {
            var userId = User.GetId();

            var post = new Post()
            {
                Title = model.Title,
                Body = model.Body,
                Summary = model.Summary,
                AuthorId = userId,
                posterURL = model.posterURL,
                creationDate = DateTime.Now
            };

            data.Add(post);

            await data.SaveChangesAsync();

            return Created(nameof(this.Create), post.PostId);
        }


    }
}