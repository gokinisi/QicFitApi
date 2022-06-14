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
    public class AgeGroupRepository : BaseRepository<AgeGroup, QicFitDataContext>, IAgeGroupRepository
    {
        public AgeGroupRepository(QicFitDataContext context) : base(context)
        {
        }
        public override async Task<bool> Exists(AgeGroup obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.AgeGroups.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<IEnumerable<AgeGroup>> GetList(ContextSession session)
        {
            var context = GetContext(session);

            var query = context.AgeGroups.AsQueryable();

            return await query.OrderBy(o => o.Order).ToArrayAsync();
        }

        public override async Task<AgeGroup> Get(int id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.AgeGroups
                .Where(obj => obj.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        
    }
}
