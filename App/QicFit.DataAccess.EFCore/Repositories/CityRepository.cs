using Common.DataAccess.EFCore;
using QicFit.Entities;
using QicFit.Services.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QicFit.DataAccess.EFCore.Repositories
{
    public class CityRepository : BaseRepository<City, QicFitDataContext>, ICityRepository
    {
        public CityRepository(QicFitDataContext context) : base(context)
        {
        }

        public override async Task<bool> Exists(City obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.City.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<IEnumerable<City>> GetList(ContextSession session)
        {
            var context = GetContext(session);

            var query = context.City.Where(c => c.Active)
                        .Include(s => s.State)        
                        .AsQueryable();

            return await query.ToArrayAsync();
        }

        public async override Task<City> Get(int id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.City
                .Where(obj => obj.Id == id)
                .Include(s => s.State)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<City>> Search(string predicate, ContextSession session)
        {
            var context = GetContext(session);

            var query = context.City
                        .Where(c => c.County.StartsWith(predicate))
                        .Include(s => s.State)
                        .AsQueryable();

            return await query.ToArrayAsync();
        }

    }
}
