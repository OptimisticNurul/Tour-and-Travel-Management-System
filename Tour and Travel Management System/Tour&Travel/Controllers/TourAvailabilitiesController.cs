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
    public class TourAvailabilitiesController : ControllerBase
    {
        private readonly TourDbContext _context;

        public TourAvailabilitiesController(TourDbContext context)
        {
            _context = context;
        }

        // GET: api/TourAvailabilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourAvailability>>> GetTourAvailabilities()
        {
            return await _context.TourAvailabilities.ToListAsync();
        }

        // GET: api/TourAvailabilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourAvailability>> GetTourAvailability(int id)
        {
            var tourAvailability = await _context.TourAvailabilities.FindAsync(id);

            if (tourAvailability == null)
            {
                return NotFound();
            }

            return tourAvailability;
        }

        // PUT: api/TourAvailabilities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourAvailability(int id, TourAvailability tourAvailability)
        {
            if (id != tourAvailability.TourAvailabilityId)
            {
                return BadRequest();
            }

            _context.Entry(tourAvailability).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourAvailabilityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tourAvailability);
        }

        // POST: api/TourAvailabilities
        [HttpPost]
        public async Task<ActionResult<TourAvailability>> PostTourAvailability(TourAvailability tourAvailability)
        {
            _context.TourAvailabilities.Add(tourAvailability);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTourAvailability", new { id = tourAvailability.TourAvailabilityId }, tourAvailability);
        }

        // DELETE: api/TourAvailabilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTourAvailability(int id)
        {
            var tourAvailability = await _context.TourAvailabilities.FindAsync(id);
            if (tourAvailability == null)
            {
                return NotFound();
            }

            _context.TourAvailabilities.Remove(tourAvailability);
            await _context.SaveChangesAsync();

            return Ok("Successfully Deleted");
        }

        private bool TourAvailabilityExists(int id)
        {
            return _context.TourAvailabilities.Any(e => e.TourAvailabilityId == id);
        }
    }
}
