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
    public class SystemMessageRepository : BaseRepository<SystemMessage, QicFitDataContext>, ISystemMessageRepository
    {
        public SystemMessageRepository(QicFitDataContext context) : base(context)
        {
        }

        public override async Task<bool> Exists(SystemMessage obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.SystemMessage.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<IEnumerable<SystemMessage>> GetList(ContextSession session)
        {
            var context = GetContext(session);

            var query = context.SystemMessage.AsQueryable();

            return await query.ToArrayAsync();
        }

        public async override Task<SystemMessage> Get(int id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.SystemMessage
                .Where(obj => obj.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
