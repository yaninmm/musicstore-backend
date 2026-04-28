using Microsoft.EntityFrameworkCore;
using MusicStore.Entities;
using MusicStore.Persistence;


namespace MusicStore.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext context;

        public GenreRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Genre>> GetAsync()
        {
            return await context.Genres.ToListAsync();
        }

        public async Task<Genre?> GetByIdAsync(int id)
        {
            return await context.Genres.FindAsync(id);
        }

        public async Task AddAsync(Genre genre)
        {
            context.Genres.Add(genre);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Genre genre)
        {
            var item = await context.Genres.FindAsync(id);

            if (item is not null)
            {
                item.Name = genre.Name;
                item.Status = genre.Status;
                context.Genres.Update(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var item = await context.Genres.FindAsync(id);
            if (item is not null)
            {
                context.Genres.Remove(item);
                await context.SaveChangesAsync();
            }
        }
    }
}
