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
    public class UserBlogsController : ControllerBase
    {
        private readonly HayakokiContext _context;

        public UserBlogsController(HayakokiContext context)
        {
            _context = context;
        }

        // GET: api/UserBlogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TravelBlog>>> GetTravelBlog(String id)
        {
            var travelBlog = await _context.TravelBlogs
                .Where(x => x.Author == id)
                .ToListAsync();
      
            if (travelBlog == null)
            {
                return NotFound();
            }

            return travelBlog;
        }
    }
}
