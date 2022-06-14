
using Common.Entities;
using Common.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Common.DataAccess.EFCore
{
    public abstract class BaseRoleRepository<TRole, TContext> : BaseRepository<TRole, TContext>, IRoleRepository<TRole>
        where TRole : BaseRole, new()
        where TContext : CommonDataContext
    {
        public BaseRoleRepository(TContext context) : base(context) { }

        public override async Task<bool> Exists(TRole obj, ContextSession session)
        {
            var context = GetContext(session);

            return await context.Set<TRole>().Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<TRole> Get(string name, ContextSession session)
        {
            var context = GetContext(session);

            return await context.Set<TRole>().Where(obj => obj.Name == name).AsNoTracking().FirstOrDefaultAsync();
        }

        public override async Task<TRole> Get(int id, ContextSession session)
        {
            var context = GetContext(session);

            return await context.Set<TRole>().Where(obj => obj.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
