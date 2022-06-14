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
    public class UserLocationRepository : BaseRepository<UserLocation, QicFitDataContext>, IUserLocationRepository
    {
        public UserLocationRepository(QicFitDataContext context) : base(context)
        {
        }
        public override async Task<bool> Exists(UserLocation obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.UserLocations.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<IEnumerable<UserLocation>> GetList(ContextSession session)
        {
            var context = GetContext(session);

            var query = context.UserLocations.AsQueryable(); 

            return await query.ToArrayAsync();
        }

        public override async Task<UserLocation> Get(int id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.UserLocations
                .Where(obj => obj.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        
    }
}
