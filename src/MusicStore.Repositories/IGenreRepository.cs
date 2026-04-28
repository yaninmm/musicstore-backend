using MusicStore.Entities;

namespace MusicStore.Repositories
{
    public interface IGenreRepository
    {
        Task AddAsync(Genre genre);
        Task DeleteAsync(int id);
        Task<List<Genre>> GetAsync();
        Task<Genre?> GetByIdAsync(int id);
        Task UpdateAsync(int id, Genre genre);
    }
}