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
    public class BookingIDController : ControllerBase
    {
        private readonly HayakokiContext _context;

        public BookingIDController(HayakokiContext context)
        {
            _context = context;
        }

       
        // GET: api/BookingID/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Guid>>> GetTicket(Guid id)
        {
            var ticket = await _context.Tickets
                .Where(x => x.UserId == id)
                .OrderByDescending( x => x.TravelDate)
                .Select(x => x.BookingId).Distinct()
                .ToListAsync();        
            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;

        }

        //select distinct BookingID, count(BookingID) as passCount, flightNumber from Tickets where BookingID = 'BFFEFD71-2B3A-E78D-C36C-F0921BA1EEF0'
        //group by BookingID, flightNumber
        

        // POST: api/BookingID
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<BookingQueryReturn>>> PostTicket(BookingQuery bq)
        {
            var ticket = await (from item in _context.Tickets
                              where item.BookingId == bq.BID
                              group item by new { item.BookingId, item.FlightNumber, item.TravelDate, item.BookingAmount} into grouping
                              orderby grouping.Count() descending
                              select new
                              {
                                  bookingId = grouping.Key.BookingId,
                                  flightNumber = grouping.Key.FlightNumber,
                                  passCount = grouping.Count(),
                                  bookingAmount = grouping.Key.BookingAmount,
                                  travelDate = grouping.Key.TravelDate
                              }).ToListAsync();
            if (ticket == null)
            {
                return NotFound();
            }
            List<BookingQueryReturn> res = new List<BookingQueryReturn>();
            foreach(var t in ticket){
                BookingQueryReturn temp = new BookingQueryReturn();
                temp.bookingId = t.bookingId;
                temp.flightNumber = t.flightNumber;
                temp.passCount = t.passCount;
                temp.bookingAmount = t.bookingAmount;
                temp.travelDate = t.travelDate;
                res.Add(temp);
            }
            return res;
        }

       

        private bool TicketExists(Guid id)
        {
            return _context.Tickets.Any(e => e.TicketId == id);
        }
    }
}
