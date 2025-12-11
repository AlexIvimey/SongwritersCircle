using Microsoft.AspNetCore.Mvc;
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

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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
    }
}
