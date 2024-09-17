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
    public class TourCancellationsController : ControllerBase
    {
        private readonly TourDbContext _context;

        public TourCancellationsController(TourDbContext context)
        {
            _context = context;
        }

        // GET: api/TourCancellations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourCancellation>>> GetTourCancellations()
        {
            return await _context.TourCancellations.ToListAsync();
        }

        // GET: api/TourCancellations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourCancellation>> GetTourCancellation(int id)
        {
            var tourCancellation = await _context.TourCancellations.FindAsync(id);

            if (tourCancellation == null)
            {
                return NotFound();
            }

            return tourCancellation;
        }

        // PUT: api/TourCancellations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourCancellation(int id, TourCancellation tourCancellation)
        {
            if (id != tourCancellation.TourCancellationId)
            {
                return BadRequest();
            }

            _context.Entry(tourCancellation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourCancellationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tourCancellation);
        }

        // POST: api/TourCancellations
        [HttpPost]
        public async Task<ActionResult<TourCancellation>> PostTourCancellation(TourCancellation tourCancellation)
        {
            _context.TourCancellations.Add(tourCancellation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTourCancellation", new { id = tourCancellation.TourCancellationId }, tourCancellation);
        }

        // DELETE: api/TourCancellations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTourCancellation(int id)
        {
            var tourCancellation = await _context.TourCancellations.FindAsync(id);
            if (tourCancellation == null)
            {
                return NotFound();
            }

            _context.TourCancellations.Remove(tourCancellation);
            await _context.SaveChangesAsync();

            return Ok("Successfully Deleted");
        }

        private bool TourCancellationExists(int id)
        {
            return _context.TourCancellations.Any(e => e.TourCancellationId == id);
        }
    }
}
