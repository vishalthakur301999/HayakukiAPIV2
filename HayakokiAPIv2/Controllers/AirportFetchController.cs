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
    public class AirportFetchController : ControllerBase
    {
        private readonly HayakokiContext _context;

        public AirportFetchController(HayakokiContext context)
        {
            _context = context;
        }

        // GET: api/AirportFetch
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Airport>>> GetAirports()
        {
            return await _context.Airports.ToListAsync();
        }

        // GET: api/AirportFetch/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Airport>> GetAirport(string id)
        {
            var airport = await _context.Airports.FindAsync(id);

            if (airport == null)
            {
                return NotFound();
            }

            return airport;
        }

       
    }
}
