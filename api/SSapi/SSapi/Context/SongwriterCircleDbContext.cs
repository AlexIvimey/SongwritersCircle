using Microsoft.EntityFrameworkCore;
using SCapi.Models;

namespace SCapi.Context
{
    public class SongwriterCircleDbContext(DbContextOptions<SongwriterCircleDbContext> options) : DbContext(options)
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
