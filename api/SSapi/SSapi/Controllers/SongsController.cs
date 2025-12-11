using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCapi.Context;
using SCapi.Models;

namespace SCapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly SongwriterCircleDbContext _context;
        public SongsController(SongwriterCircleDbContext context)
        {
            _context = context;
        }

        // POST: SongsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Song song)
        {
            _context.Add(song);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtAction(nameof(Create), song);
        }

        // PUT SongsController/{id}
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, Song song)
        {
            if (id < 1 || !_context.Songs.Any(s => s.Id == id) || id != song.Id)
            {
                return BadRequest("The resource does not exist");
            }

            // get the song
            _context.Entry(song).State = EntityState.Modified;

            //try to save
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Invalid song");
            }
            return Ok();
        }


        // DELETE: SongsController/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
            return Ok("Song deleted successfully");
        }

        // GET: SongsController/Get
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> Get()
        {
            return await _context.Songs.ToListAsync();
        }

        // GET: SongsController/GetOne
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetOne(int id)
        {
            if(id < 1)
            {
                return NotFound();
            }
            var song = await _context.Songs.FindAsync(id);

            if(song == null)
            {
                return NotFound();
            }
            return song;
        }
    }
}
