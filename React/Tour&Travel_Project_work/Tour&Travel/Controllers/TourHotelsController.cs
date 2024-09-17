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
    public class TourHotelsController : ControllerBase
    {
        private readonly TourDbContext _context;

        public TourHotelsController(TourDbContext context)
        {
            _context = context;
        }

        // GET: api/TourHotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourHotel>>> GetTourHotels()
        {
            return await _context.TourHotels.ToListAsync();
        }

        // GET: api/TourHotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourHotel>> GetTourHotel(int id)
        {
            var tourHotel = await _context.TourHotels.FindAsync(id);

            if (tourHotel == null)
            {
                return NotFound();
            }

            return tourHotel;
        }

        // PUT: api/TourHotels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourHotel(int id, TourHotel tourHotel)
        {
            if (id != tourHotel.TourHotelId)
            {
                return BadRequest();
            }

            _context.Entry(tourHotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourHotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tourHotel);
        }

        // POST: api/TourHotels
        [HttpPost]
        public async Task<ActionResult<TourHotel>> PostTourHotel(TourHotel tourHotel)
        {
            _context.TourHotels.Add(tourHotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTourHotel", new { id = tourHotel.TourHotelId }, tourHotel);
        }

        // DELETE: api/TourHotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTourHotel(int id)
        {
            var tourHotel = await _context.TourHotels.FindAsync(id);
            if (tourHotel == null)
            {
                return NotFound();
            }

            _context.TourHotels.Remove(tourHotel);
            await _context.SaveChangesAsync();

            return Ok("Successfully Deleted");
        }

        private bool TourHotelExists(int id)
        {
            return _context.TourHotels.Any(e => e.TourHotelId == id);
        }
    }
}
