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
    public class TourPackagesController : ControllerBase
    {
        private readonly TourDbContext _context;

        public TourPackagesController(TourDbContext context)
        {
            _context = context;
        }

        // GET: api/TourPackages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourPackage>>> GetTourPackages()
        {
            
            return await _context.TourPackages.ToListAsync();
        }

        // GET: api/TourPackages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourPackage>> GetTourPackage(int id)
        {
            var tourPackage = await _context.TourPackages.FindAsync(id);

            if (tourPackage == null)
            {
                return NotFound();
            }

            return tourPackage;
        }

        // PUT: api/TourPackages/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutTourPackage(int id, TourPackage tourPackage)
        {
            if (id != tourPackage.TourPackageId)
            {
                return BadRequest();
            }

            var existingTourPackage = await _context.TourPackages.FindAsync(id);

            if (existingTourPackage == null)
            {
                return NotFound();
            }

            // Update other properties similarly
            existingTourPackage.TourTransportIds = tourPackage.TourTransportIds;
            existingTourPackage.TourHotelIds = tourPackage.TourHotelIds;
            existingTourPackage.TourFoodIds = tourPackage.TourFoodIds;
            existingTourPackage.TourGuideIds = tourPackage.TourGuideIds;

            // Recalculate TotalAmount
            decimal totalPrice = 0;

            foreach (int transportId in existingTourPackage.TourTransportIds)
            {
                var transportPrice = _context.TourTransports
                    .Where(t => t.TourTransportId == transportId)
                    .Select(t => t.RentPerPerson)
                    .FirstOrDefault();
                totalPrice += transportPrice;
            }

            foreach (int hotelId in existingTourPackage.TourHotelIds)
            {
                var hotelPrice = _context.TourHotels
                    .Where(h => h.TourHotelId == hotelId)
                    .Select(h => h.PricePerNight)
                    .FirstOrDefault();
                totalPrice += hotelPrice;
            }

            foreach (int foodId in existingTourPackage.TourFoodIds)
            {
                var foodPrice = _context.TourFoods
                    .Where(f => f.TourFoodId == foodId)
                    .Select(f => f.Price)
                    .FirstOrDefault();
                totalPrice += foodPrice;
            }

            foreach (int guideId in existingTourPackage.TourGuideIds)
            {
                var guideFee = _context.TourGuides
                    .Where(g => g.TourGuideId == guideId)
                    .Select(g => g.GuideFee)
                    .FirstOrDefault();
                totalPrice += guideFee;
            }

            existingTourPackage.TotalAmount = totalPrice;

            _context.Entry(existingTourPackage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourPackageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(existingTourPackage);
        }


        // POST: api/TourPackages
        [HttpPost]
        public async Task<ActionResult<TourPackage>> PostTourPackage(TourPackage tourPackage)
        {
            // Calculate total amount based on multiple tour transport, hotel, food, and guide IDs
            decimal totalPrice = 0;

            foreach (int transportId in tourPackage.TourTransportIds)
            {
                var transportPrice = _context.TourTransports
                    .Where(t => t.TourTransportId == transportId)
                    .Select(t => t.RentPerPerson)
                    .FirstOrDefault();
                totalPrice += transportPrice;
            }

            foreach (int hotelId in tourPackage.TourHotelIds)
            {
                var hotelPrice = _context.TourHotels
                    .Where(h => h.TourHotelId == hotelId)
                    .Select(h => h.PricePerNight)
                    .FirstOrDefault();
                totalPrice += hotelPrice;
            }

            foreach (int foodId in tourPackage.TourFoodIds)
            {
                var foodPrice = _context.TourFoods
                    .Where(f => f.TourFoodId == foodId)
                    .Select(f => f.Price)
                    .FirstOrDefault();
                totalPrice += foodPrice;
            }

            foreach (int guideId in tourPackage.TourGuideIds)
            {
                var guideFee = _context.TourGuides
                    .Where(g => g.TourGuideId == guideId)
                    .Select(g => g.GuideFee)
                    .FirstOrDefault();
                totalPrice += guideFee;
            }

            tourPackage.TotalAmount = totalPrice;

            _context.TourPackages.Add(tourPackage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTourPackage", new { id = tourPackage.TourPackageId }, tourPackage);
        }

        // DELETE: api/TourPackages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTourPackage(int id)
        {
            var tourPackage = await _context.TourPackages.FindAsync(id);
            if (tourPackage == null)
            {
                return NotFound();
            }

            _context.TourPackages.Remove(tourPackage);
            await _context.SaveChangesAsync();

            return Ok("Successfully Deleted");
        }

        private bool TourPackageExists(int id)
        {
            return _context.TourPackages.Any(e => e.TourPackageId == id);
        }
    }
}
