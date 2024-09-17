using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
    public class ToursController : ControllerBase
    {
        private readonly TourDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ToursController(TourDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/Tours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tour>>> GetTours()
        {
            return await _context.Tours.ToListAsync();
        }

        // GET: api/Tours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tour>> GetTour(int id)
        {
            var tour = await _context.Tours
                .Include(t => t.TourPackage)
                .Include(t => t.TourBooking)
                .Include(t => t.TourAvailabilities)
                .Include(t => t.TourImage)
                .FirstOrDefaultAsync(t => t.TourId == id);

            if (tour == null)
            {
                return NotFound();
            }

            return tour;
        }

        // PUT: api/Tours/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTour(int id, [FromForm] TourImageVM tourImageVM)
        {
            if (id != tourImageVM.TourId)
            {
                return BadRequest("Invalid tour ID.");
            }

            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound("Tour not found.");
            }

            // Update tour properties
            tour.TourName = tourImageVM.TourName;
            tour.Destination = tourImageVM.Destination;
            tour.Duration = tourImageVM.Duration;
            tour.DepartureTime = tourImageVM.DepartureTime;
            tour.ArrivalTime = tourImageVM.ArrivalTime;
            tour.Description = tourImageVM.Description;
            tour.TourPackageId = tourImageVM.TourPackageId;

            _context.Entry(tour).State = EntityState.Modified;

            // Handle image update if new images are provided
            if (tourImageVM.ImageFile != null && tourImageVM.ImageFile.Count > 0)
            {
                // Delete existing tour images
                var existingImages = await _context.TourImages.Where(ti => ti.TourId == id).ToListAsync();
                foreach (var image in existingImages)
                {
                    var imagePath = Path.Combine(_env.WebRootPath, "Images", image.Picture);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                    _context.TourImages.Remove(image);
                }

                // Add new tour images
                foreach (var item in tourImageVM.ImageFile)
                {
                    if (item.Length == 0)
                    {
                        continue;
                    }

                    var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(item.FileName)}";
                    var filePath = Path.Combine(_env.WebRootPath, "Images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }

                    var newTourImage = new TourImage
                    {
                        TourId = id,
                        Picture = fileName
                    };

                    _context.TourImages.Add(newTourImage);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tour);
        }


        // POST: api/Tours
        [HttpPost]
        public async Task<ActionResult<Tour>> PostTour([FromForm] TourImageVM tourImageVM)
        {
            if (tourImageVM == null || tourImageVM.ImageFile == null || tourImageVM.ImageFile.Count == 0)
            {
                return BadRequest("No image files were provided.");
            }

            var tour = new Tour
            {
                TourName = tourImageVM.TourName,
                Destination = tourImageVM.Destination,
                Duration = tourImageVM.Duration,
                DepartureTime = tourImageVM.DepartureTime,
                ArrivalTime = tourImageVM.ArrivalTime,
                Description = tourImageVM.Description,
                TourPackageId = tourImageVM.TourPackageId
            };

            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();

            var lastTourId = tour.TourId;


            TourAvailability tourAvailability = new TourAvailability
            {
                TourId = lastTourId,
                Date = tourImageVM.Date,
                AvailableSlots= tourImageVM.AvailableSlots
            };
            _context.TourAvailabilities.Add(tourAvailability);
            await _context.SaveChangesAsync();



            foreach (var item in tourImageVM.ImageFile)
            {
                if (item.Length == 0)
                {
                    continue;
                }

                var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(item.FileName)}";
                var filePath = Path.Combine(_env.WebRootPath, "Images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }

                var tourImage = new TourImage
                {
                    TourId = lastTourId,
                    Picture = fileName
                };

                _context.TourImages.Add(tourImage);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTour", new { id = tour.TourId }, tour);
        }

        // DELETE: api/Tours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }

            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();

            return Ok("Tour deleted successfully.");
        }

        private bool TourExists(int id)
        {
            return _context.Tours.Any(e => e.TourId == id);
        }
    }
}