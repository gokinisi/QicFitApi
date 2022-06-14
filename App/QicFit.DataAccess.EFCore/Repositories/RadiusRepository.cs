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
    public class RadiusRepository : BaseRepository<Radius, QicFitDataContext>, IRadiusRepository
    {
        public RadiusRepository(QicFitDataContext context) : base(context)
        {
        }

        public override async Task<bool> Exists(Radius obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Radius.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<IEnumerable<Radius>> GetList(ContextSession session)
        {
            var context = GetContext(session);

            return await context.Radius.OrderBy(o => o.Order).ToArrayAsync();
        }

        public override async Task<Radius> Get(int id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Radius
                .Where(obj => obj.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        
    }
}
