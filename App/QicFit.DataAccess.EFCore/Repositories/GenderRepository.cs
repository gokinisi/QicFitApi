using Common.DataAccess.EFCore;
using QicFit.Entities;
using QicFit.Services.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QicFit.DataAccess.EFCore.Repositories
{
    public class GenderRepository : BaseRepository<Gender, QicFitDataContext>, IGenderRepository
    {
        public GenderRepository(QicFitDataContext context) : base(context)
        {
        }
        public override async Task<bool> Exists(Gender obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Gender.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<IEnumerable<Gender>> GetList(ContextSession session)
        {
            var context = GetContext(session);

            var query = context.Gender.OrderBy(o => o.Order).AsQueryable();

            return await query.ToArrayAsync();
        }

        public override async Task<Gender> Get(int id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Gender
                .Where(obj => obj.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        
    }
}
