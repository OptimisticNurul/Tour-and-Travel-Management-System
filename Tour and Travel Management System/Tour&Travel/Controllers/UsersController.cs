using System;
using NSwag.Annotations;
using Swashbuckle.AspNetCore.Annotations;
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
    public class UsersController : ControllerBase
    {
        private readonly TourDbContext _context;
        private readonly IWebHostEnvironment _env;

        public UsersController(TourDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromForm] UserVM userVM)
        {
            try
            {
                if (id != userVM.UserId)
                {
                    return BadRequest("Invalid user ID");
                }

                var existingUser = await _context.Users.FindAsync(id);
                if (existingUser == null)
                {
                    return NotFound("User not found");
                }

                existingUser.UserName = userVM.UserName;
                existingUser.Password = userVM.Password;
                existingUser.Email = userVM.Email;
                existingUser.Role = userVM.Role;

                // Image handling
                if (userVM.ImageFile != null)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(userVM.ImageFile.FileName);
                    var filePath = Path.Combine(_env.WebRootPath, "Images", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await userVM.ImageFile.CopyToAsync(fileStream);
                    }

                    existingUser.ProfileImage = fileName;
                }

                _context.Entry(existingUser).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(existingUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromForm] UserVM userVM)
        {
            try
            {
                User user = new User
                {
                    UserName = userVM.UserName,
                    Password = userVM.Password,
                    Email = userVM.Email,
                    Role = userVM.Role
                };

                // Image handling
                if (userVM.ImageFile != null)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(userVM.ImageFile.FileName);
                    var filePath = Path.Combine(_env.WebRootPath, "Images", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await userVM.ImageFile.CopyToAsync(fileStream);
                    }

                    user.ProfileImage = fileName;
                }

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUser", new { id = user.UserId }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("Successfully Deleted");
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
