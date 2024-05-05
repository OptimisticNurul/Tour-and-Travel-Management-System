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
    public class TourImagesController : ControllerBase
    {
        private readonly TourDbContext _context;

        public TourImagesController(TourDbContext context)
        {
            _context = context;
        }

        // GET: api/TourImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourImage>>> GetTourImages()
        {
            return await _context.TourImages.ToListAsync();
        }

        // GET: api/TourImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourImage>> GetTourImage(int id)
        {
            var tourImage = await _context.TourImages.FindAsync(id);

            if (tourImage == null)
            {
                return NotFound();
            }

            return tourImage;
        }

        // PUT: api/TourImages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourImage(int id, TourImage tourImage)
        {
            if (id != tourImage.TourImageId)
            {
                return BadRequest();
            }

            _context.Entry(tourImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourImageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tourImage);
        }

        // POST: api/TourImages
        [HttpPost]
        public async Task<ActionResult<TourImage>> PostTourImage(TourImage tourImage)
        {
            _context.TourImages.Add(tourImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTourImage", new { id = tourImage.TourImageId }, tourImage);
        }

        // DELETE: api/TourImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTourImage(int id)
        {
            var tourImage = await _context.TourImages.FindAsync(id);
            if (tourImage == null)
            {
                return NotFound();
            }

            _context.TourImages.Remove(tourImage);
            await _context.SaveChangesAsync();

            return Ok("Successfully Deleted");
        }

        private bool TourImageExists(int id)
        {
            return _context.TourImages.Any(e => e.TourImageId == id);
        }
    }
}
