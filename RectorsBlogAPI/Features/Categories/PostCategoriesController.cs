using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RectorsBlogAPI.Data;
using RectorsBlogAPI.Features.Categories.Models;

namespace RectorsBlogAPI.Features.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PostCategories
        [HttpGet]
        public IEnumerable<PostCategory> GetPostCategories()
        {
            return _context.PostCategories;
        }

        // GET: api/PostCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postCategory = await _context.PostCategories.FindAsync(id);

            if (postCategory == null)
            {
                return NotFound();
            }

            return Ok(postCategory);
        }

        // PUT: api/PostCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostCategory([FromRoute] int id, [FromBody] PostCategory postCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postCategory.PostId)
            {
                return BadRequest();
            }

            _context.Entry(postCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostCategoryExists(id))
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

        // POST: api/PostCategories
        [HttpPost]
        public async Task<IActionResult> PostPostCategory([FromBody] PostCategory postCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PostCategories.Add(postCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PostCategoryExists(postCategory.PostId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPostCategory", new { id = postCategory.PostId }, postCategory);
        }

        // DELETE: api/PostCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postCategory = await _context.PostCategories.FindAsync(id);
            if (postCategory == null)
            {
                return NotFound();
            }

            _context.PostCategories.Remove(postCategory);
            await _context.SaveChangesAsync();

            return Ok(postCategory);
        }

        private bool PostCategoryExists(int id)
        {
            return _context.PostCategories.Any(e => e.PostId == id);
        }
    }
}