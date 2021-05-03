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
    public class UsernameCheckCotroller : ControllerBase
    {
        private readonly HayakokiContext _context;

        public UsernameCheckCotroller(HayakokiContext context)
        {
            _context = context;
        }

  

        // GET: api/UsernameCheckCotroller/5
        [HttpGet("{id}")]
        public async Task<ActionResult<bool>> GetUser(string id)
        {
              List<User> res = await _context.Users
                .Where(x => x.UserName == id)
                .ToListAsync();
            if (res.Count == 0)
            {
                return false;
            }
            else {
                return true;
            }
            
        }

        
    }
}
