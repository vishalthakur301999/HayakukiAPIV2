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
    public class FlightQueryController : ControllerBase
    {
        private readonly HayakokiContext _context;

        public FlightQueryController(HayakokiContext context)
        {
            _context = context;
        }

        // POST: api/Flight
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Flight>>> PostFlight(flightquery flightquery)
        {
            if (flightquery.sortdirection == "asc")
            {
                switch (flightquery.sortby)
                {
                    case "Fare":
                        {
                            var reqData = await _context.Flights
                            .Where(x => x.SourceCode == flightquery.From && x.DestCode == flightquery.To).OrderBy(x => x.Fare).ToListAsync();
                            return reqData;
                        }
                    case "DeptTime":
                        {
                            var reqData = await _context.Flights
                            .Where(x => x.SourceCode == flightquery.From && x.DestCode == flightquery.To).OrderBy(x => x.DeptTime).ToListAsync();
                            return reqData;
                        }
                    case "ArrivalTime":
                        {
                            var reqData = await _context.Flights
                            .Where(x => x.SourceCode == flightquery.From && x.DestCode == flightquery.To).OrderBy(x => x.ArrivalTime).ToListAsync();
                            return reqData;
                        }
                    case "Duration":
                        {
                            var reqData = await _context.Flights
                            .Where(x => x.SourceCode == flightquery.From && x.DestCode == flightquery.To).OrderBy(x => x.Duration).ToListAsync();
                            return reqData;
                        }
                    default: return null;
                }
            }
            else
            {
                switch (flightquery.sortby)
                {
                    case "Fare":
                        {
                            var reqData = await _context.Flights
                            .Where(x => x.SourceCode == flightquery.From && x.DestCode == flightquery.To).OrderByDescending(x => x.Fare).ToListAsync();
                            return reqData;
                        }
                    case "DeptTime":
                        {
                            var reqData = await _context.Flights
                            .Where(x => x.SourceCode == flightquery.From && x.DestCode == flightquery.To).OrderByDescending(x => x.DeptTime).ToListAsync();
                            return reqData;
                        }
                    case "ArrivalTime":
                        {
                            var reqData = await _context.Flights
                            .Where(x => x.SourceCode == flightquery.From && x.DestCode == flightquery.To).OrderByDescending(x => x.ArrivalTime).ToListAsync();
                            return reqData;
                        }
                    case "Duration":
                        {
                            var reqData = await _context.Flights
                            .Where(x => x.SourceCode == flightquery.From && x.DestCode == flightquery.To).OrderByDescending(x => x.Duration).ToListAsync();
                            return reqData;
                        }
                    default: return null;
                }
            }

        }


        private bool FlightExists(string id)
        {
            return _context.Flights.Any(e => e.FlightNumber == id);
        }
    }
}
