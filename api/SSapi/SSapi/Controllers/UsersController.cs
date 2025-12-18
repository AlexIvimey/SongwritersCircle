using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCapi.Context;
using SCapi.Models;

namespace SCapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SongwriterCircleDbContext _context;
        public UsersController(SongwriterCircleDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            _context.Add(user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtAction(nameof(Create), user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, User user)
        {
            if (id < 1 || !_context.Users.Any(u => u.Id == id) || id != user.Id)
            {
                return NotFound();
            }
            _context.Update(user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Invalid Values entered for User");
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id < 1 || !_context.Users.Any(u => u.Id == id))
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetOne(int id)
        {
            if(id < 1)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            return user;
        }
    }
}
