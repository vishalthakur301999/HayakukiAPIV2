using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HayakokiAPIv2.Models;

namespace HayakokiAPIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly HayakokiContext _context;

        public BlogController(HayakokiContext context)
        {
            _context = context;
        }

        // GET: api/Blog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelBlog>>> GetTravelBlogs()
        {
            return await _context.TravelBlogs.ToListAsync();
        }

        // GET: api/Blog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelBlog>> GetTravelBlog(Guid id)
        {
            var travelBlog = await _context.TravelBlogs.FindAsync(id);

            if (travelBlog == null)
            {
                return NotFound();
            }

            return travelBlog;
        }

        // PUT: api/Blog/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTravelBlog(Guid id, TravelBlog travelBlog)
        {
            if (id != travelBlog.Blogid)
            {
                return BadRequest();
            }

            _context.Entry(travelBlog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelBlogExists(id))
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

        // POST: api/Blog
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TravelBlog>> PostTravelBlog(TravelBlog travelBlog)
        {
            _context.TravelBlogs.Add(travelBlog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTravelBlog", new { id = travelBlog.Blogid }, travelBlog);
        }

        // DELETE: api/Blog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelBlog(Guid id)
        {
            var travelBlog = await _context.TravelBlogs.FindAsync(id);
            if (travelBlog == null)
            {
                return NotFound();
            }

            _context.TravelBlogs.Remove(travelBlog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TravelBlogExists(Guid id)
        {
            return _context.TravelBlogs.Any(e => e.Blogid == id);
        }
    }
}
