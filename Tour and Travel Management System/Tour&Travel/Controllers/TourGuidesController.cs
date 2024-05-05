using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tour_Travel.Data;
using Tour_Travel.Models;
using Tour_Travel.ViewModels;

namespace Tour_Travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourGuidesController : ControllerBase
    {
        private readonly TourDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TourGuidesController(TourDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/TourGuides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourGuide>>> GetTourGuides()
        {
            return await _context.TourGuides.ToListAsync();
        }

        // GET: api/TourGuides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourGuide>> GetTourGuide(int id)
        {
            var tourGuide = await _context.TourGuides.FindAsync(id);

            if (tourGuide == null)
            {
                return NotFound();
            }

            return tourGuide;
        }

        // PUT: api/TourGuide/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourGuide(int id, [FromForm] TourGuideVM tourGuideVM)
        {
            try
            {
                if (id != tourGuideVM.TourGuideId)
                {
                    return BadRequest("Invalid Tour Guide ID");
                }

                var existingTourGuide = await _context.TourGuides.FindAsync(id);
                if (existingTourGuide == null)
                {
                    return NotFound("Tour Guide not found");
                }

                existingTourGuide.Name = tourGuideVM.Name;
                existingTourGuide.Age = tourGuideVM.Age;
                existingTourGuide.Gender = tourGuideVM.Gender;
                existingTourGuide.Email = tourGuideVM.Email;
                existingTourGuide.Phone = tourGuideVM.Phone;
                existingTourGuide.GuideFee = tourGuideVM.GuideFee;

                // Image handling
                if (tourGuideVM.ImageFile != null)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(tourGuideVM.ImageFile.FileName);
                    var filePath = Path.Combine(_env.WebRootPath, "Images", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await tourGuideVM.ImageFile.CopyToAsync(fileStream);
                    }

                    existingTourGuide.Image = fileName;
                }

                _context.Entry(existingTourGuide).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(existingTourGuide);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/TourGuide
        [HttpPost]
        public async Task<ActionResult<User>> PostTourGuide([FromForm] TourGuideVM tourGuideVM)
        {
            try
            {
                TourGuide tourGuide = new TourGuide
                {
                    Name = tourGuideVM.Name,
                    Age = tourGuideVM.Age,
                    Gender = tourGuideVM.Gender,
                    Email = tourGuideVM.Email,
                    Phone = tourGuideVM.Phone,
                    GuideFee= tourGuideVM.GuideFee,
                    
                };

                // Image handling
                if (tourGuideVM.ImageFile != null)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(tourGuideVM.ImageFile.FileName);
                    var filePath = Path.Combine(_env.WebRootPath, "Images", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await tourGuideVM.ImageFile.CopyToAsync(fileStream);
                    }

                    tourGuide.Image = fileName;
                }

                _context.TourGuides.Add(tourGuide);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTourGuide", new { id = tourGuide.TourGuideId }, tourGuide);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/TourGuides/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTourGuide(int id)
        {
            var tourGuide = await _context.TourGuides.FindAsync(id);
            if (tourGuide == null)
            {
                return NotFound();
            }

            _context.TourGuides.Remove(tourGuide);
            await _context.SaveChangesAsync();

            return Ok("Successfully Deleted");
        }

        private bool TourGuideExists(int id)
        {
            return _context.TourGuides.Any(e => e.TourGuideId == id);
        }
    }
}
