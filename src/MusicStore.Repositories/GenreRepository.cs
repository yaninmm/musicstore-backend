using MusicStore.Entities;
using MusicStore.Persistence;


namespace MusicStore.Repositories
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context)
        {

        }
        //private readonly ApplicationDbContext context;

        //public GenreRepository(ApplicationDbContext context)
        //{
        //    this.context = context;
        //}

        //public async Task<List<GenreResponseDto>> GetAsync()
        //{
        //    var items = await context.Set<Genre>()
        //        .AsNoTracking()
        //        .ToListAsync();
        //    return items.Select(x => new GenreResponseDto
        //    {
        //        Id = x.Id,
        //        Name = x.Name,
        //        Status = x.Status
        //    }).ToList();
        //}

        //public async Task<GenreResponseDto?> GetByIdAsync(int id)
        //{
        //    var item = await context.Set<Genre>()
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(x=> x.Id == id);
        //    if(item is not null)
        //    {
        //        return new GenreResponseDto
        //        {
        //            Id = item.Id,
        //            Name = item.Name,
        //            Status = item.Status
        //        };
        //    }
        //    else
        //        throw new KeyNotFoundException($"Genre with id {id} not found.");
        //}

        //public async Task<int> AddAsync(GenreRequestDto genre)
        //{
        //    var entity = new Genre
        //    {
        //        Name = genre.Name,
        //        Status = genre.Status
        //    };
        //    context.Set<Genre>().Add(entity);
        //    await context.SaveChangesAsync();
        //    return entity.Id;
        //}

        //public async Task UpdateAsync(int id, GenreRequestDto genre)
        //{
        //    var item = await context.Set<Genre>()
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(x => x.Id == id);

        //    if (item is not null)
        //    {
        //        item.Name = genre.Name;
        //        item.Status = genre.Status;
        //        context.Set<Genre>().Update(item);
        //        await context.SaveChangesAsync();
        //    }
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var item = await GetAsync(id);
        //    //var item = await context
        //    //    .Set<Genre>()
        //    //    .AsNoTracking() //hace que las operaciones de lectura sean más eficientes
        //    //    .FirstOrDefaultAsync(x => x.Id == id);
        //    if (item is not null)
        //    {
        //        context.Set<Genre>().Remove(item);
        //        await context.SaveChangesAsync();
        //    }
        //}
    }
}
