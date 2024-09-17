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
    public class TourFoodsController : ControllerBase
    {
        private readonly TourDbContext _context;

        public TourFoodsController(TourDbContext context)
        {
            _context = context;
        }

        // GET: api/TourFoods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourFood>>> GetTourFoods()
        {
            return await _context.TourFoods.ToListAsync();
        }

        // GET: api/TourFoods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourFood>> GetTourFood(int id)
        {
            var tourFood = await _context.TourFoods.FindAsync(id);

            if (tourFood == null)
            {
                return NotFound();
            }

            return tourFood;
        }

        // PUT: api/TourFoods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourFood(int id, TourFood tourFood)
        {
            if (id != tourFood.TourFoodId)
            {
                return BadRequest();
            }

            _context.Entry(tourFood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourFoodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tourFood);
        }

        // POST: api/TourFoods
        [HttpPost]
        public async Task<ActionResult<TourFood>> PostTourFood(TourFood tourFood)
        {
            _context.TourFoods.Add(tourFood);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTourFood", new { id = tourFood.TourFoodId }, tourFood);
        }

        // DELETE: api/TourFoods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTourFood(int id)
        {
            var tourFood = await _context.TourFoods.FindAsync(id);
            if (tourFood == null)
            {
                return NotFound();
            }

            _context.TourFoods.Remove(tourFood);
            await _context.SaveChangesAsync();

            return Ok("Successfully Deleted");
        }

        private bool TourFoodExists(int id)
        {
            return _context.TourFoods.Any(e => e.TourFoodId == id);
        }
    }
}
