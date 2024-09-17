using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tour_Travel.Data;
using Tour_Travel.Models;

namespace Tour_Travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourTransportsController : ControllerBase
    {
        private readonly TourDbContext _context;

        public TourTransportsController(TourDbContext context)
        {
            _context = context;
        }

        // GET: api/TourTransports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourTransport>>> GetTourTransports()
        {
            return await _context.TourTransports.ToListAsync();
        }

        // GET: api/TourTransports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourTransport>> GetTourTransport(int id)
        {
            var tourTransport = await _context.TourTransports.FindAsync(id);

            if (tourTransport == null)
            {
                return NotFound();
            }

            return tourTransport;
        }

        // PUT: api/TourTransports/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourTransport(int id, TourTransport tourTransport)
        {
            if (id != tourTransport.TourTransportId)
            {
                return BadRequest();
            }

            _context.Entry(tourTransport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourTransportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tourTransport);
        }

        // POST: api/TourTransports
        [HttpPost]
        public async Task<ActionResult<TourTransport>> PostTourTransport(TourTransport tourTransport)
        {
            _context.TourTransports.Add(tourTransport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTourTransport", new { id = tourTransport.TourTransportId }, tourTransport);
        }

        // DELETE: api/TourTransports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTourTransport(int id)
        {
            var tourTransport = await _context.TourTransports.FindAsync(id);
            if (tourTransport == null)
            {
                return NotFound();
            }

            _context.TourTransports.Remove(tourTransport);
            await _context.SaveChangesAsync();

            return Ok("Successfully Deleted");
        }

        private bool TourTransportExists(int id)
        {
            return _context.TourTransports.Any(e => e.TourTransportId == id);
        }
    }
}
