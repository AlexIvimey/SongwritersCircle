using Microsoft.EntityFrameworkCore;
using SCapi.Models;

namespace SCapi.Context
{
    public class SongwriterCircleDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
