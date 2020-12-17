using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RectorsBlogAPI.Data;
using RectorsBlogAPI.Features.Comments.Models;
using RectorsBlogAPI.Features.Identity.Models;
using RectorsBlogAPI.Infrastructure.Extensions;

namespace RectorsBlogAPI.Features.Comments
{
    public class CommentsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _users;

        public CommentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _users = userManager;
        }

        // GET: api/Comments
        [HttpGet]
        public IEnumerable<Comment> GetComments()
        {
            return _context.Comments;
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<CommentResponseModel>> GetCommentsByPostId([FromRoute] int id)
        {
            var comments = await _context
                .Comments
                .Where(c => c.PostId == id)
                .Select(c => new CommentResponseModel
                {
                    AuthorId = c.AuthorId,
                    AuthorName = c.Author.UserName,
                    Content = c.Content,
                    PostId = c.PostId,
                    creationDate = c.creationDate,
                    CommentId = c.CommentId
                })
                .OrderByDescending(c=>c.creationDate)
                .ToListAsync();

            return comments;
        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutComment([FromRoute] int id, [FromBody] Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comment.CommentId)
            {
                return BadRequest();
            }

            if (comment.AuthorId != User.GetId())
            {
                return BadRequest();
            }

            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Comments
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostComment([FromBody] Comment comment)
        {
            comment.AuthorId = User.GetId();
            comment.creationDate = DateTime.Now;
            comment.Author = await _users.GetUserAsync(User);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return Created(nameof(this.PostComment), comment.CommentId);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            if (comment.AuthorId != User.GetId()) 
            {
                return BadRequest();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return Ok(comment);
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }
    }
}