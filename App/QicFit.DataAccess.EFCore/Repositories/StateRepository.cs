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
    public class StateRepository : BaseRepository<State, QicFitDataContext>, IStateRepository
    {
        public StateRepository(QicFitDataContext context) : base(context)
        {
        }

        public override async Task<bool> Exists(State obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.State.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<IEnumerable<State>> GetList(ContextSession session)
        {
            var context = GetContext(session);

            var query = context.State.Where(s => s.Active).AsQueryable();

            return await query.ToArrayAsync();
        }

        public async override Task<State> Get(int id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.State
                .Where(obj => obj.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
