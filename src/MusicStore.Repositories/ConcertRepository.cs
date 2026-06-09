using Microsoft.EntityFrameworkCore;
using MusicStore.Entities;
using MusicStore.Entities.Info;
using MusicStore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Repositories
{
    public class ConcertRepository : RepositoryBase<Concert>, IConcertRepository
    {
        public ConcertRepository(ApplicationDbContext context) : base(context)
        {
        }

        
        public async Task<ICollection<ConcertInfo>> GetAsync(string? title)
        {
            //Lazy loading approach
            return await context.Set<Concert>()
                //.Include(g => g.Genre) //Eager loading approach 
                .Where(c => c.Title.Contains(title ?? string.Empty))
                .AsNoTracking()
                .Select(x => new ConcertInfo
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Place = x.Place,
                    UnitPrice = x.UnitPrice,
                    GenreId = x.GenreId,
                    Genre = x.Genre.Name,
                    DateEvent = x.DateEvent.ToShortDateString(),
                    TimeEvent = x.DateEvent.ToShortTimeString(),
                    Imageurl = x.Imageurl,
                    TicketsQuantity = x.TicketsQuantity,
                    Finalized = x.Finalized,
                    Status = x.Status ? "Active" : "Inactive"
                })
                .ToListAsync();

            //Raw queries approach
            //var query = context.Database.SqlQueryRaw<ConcertInfo>("usp_ListConcerts {0}", title ?? string.Empty);
            //return await query.ToListAsync();
        }

        //public virtual async Task<ICollection<Concert>> GetAsync()
        //{
        //    //Eager loading
        //    return await context.Set<Concert>()
        //        .Include(g => g.Genre)
        //        .AsNoTracking()
        //        .ToListAsync();
        //}

        public async Task FinalizeAsync(int id)
        {
            var entity = await GetAsync(id);
            if (entity is not null)
            {
                entity.Finalized = true;
                await UpdateAsync();
            }
        }
    }
}
