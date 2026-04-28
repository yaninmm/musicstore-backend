using Microsoft.EntityFrameworkCore;
using MusicStore.Entities;

namespace MusicStore.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genre>().Property(g => g.Name).IsRequired().HasMaxLength(50);
        }

        public DbSet<Genre> Genres { get; set; }
    }
}
