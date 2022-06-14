
using Common.Entities;
using Common.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.DataAccess.EFCore
{
    public abstract class BaseIdentityUserRepository<TUser, TContext> : BaseRepository<TUser, TContext>, IIdentityUserRepository<TUser>
        where TUser : BaseUser, new()
        where TContext : CommonDataContext
    {
        protected BaseIdentityUserRepository(TContext context) : base(context) { }

        public override async Task<bool> Exists(TUser obj, ContextSession session)
        {
            var context = GetContext(session);

            return await context
                .Set<TUser>()
                .Where(x => x.Id == obj.Id)
                .AsNoTracking()
                .CountAsync() > 0;
        }

        public override async Task<TUser> Edit(TUser obj, ContextSession session)
        {
            var objectExists = await Exists(obj, session);
            var context = GetContext(session);

            context.Entry(obj).State = objectExists ? EntityState.Modified : EntityState.Added;
            await context.SaveChangesAsync();
            return obj;
        }

        public override async Task<TUser> Get(int id, ContextSession session)
        {
            var context = GetContext(session);

            return await context.Set<TUser>()
                .Where(obj => obj.Id == id)
                .AsNoTracking()
                .Include(u => u.Claims)
                .Include(u => u.UserRoles)
                    .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync();
        }

        public async Task<TUser> GetByUserName(string username, ContextSession session)
        {
            var context = GetContext(session);

            return await context.Set<TUser>()
                .Where(obj => obj.UserName == username)
                .Include(u => u.Claims)
                .Include(u => u.UserRoles)
                    .ThenInclude(x => x.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<TUser> GetByEmail(string email, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Set<TUser>()
                .Include(u => u.UserRoles)
                    .ThenInclude(x => x.Role)
                .Include(u => u.Claims)
                .Where(obj => obj.Email == email)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<TUser> GetById(int id, ContextSession session)
        {
            return await Get(id, session);
        }

        public async Task<IList<TUser>> GetUsersByRole(int roleId, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Set<TUser>()
                .AsNoTracking()
                .Include(u => u.Claims)
                .Include(u => u.UserRoles)
                    .ThenInclude(x => x.Role)
                .Where(x => x.UserRoles.Any(ur => ur.RoleId == roleId))
                .ToArrayAsync();
        }

        public async Task<IList<TUser>> GetUsersByClaim(string claimType, string claimValue, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Set<TUser>()
                .AsNoTracking()
                .Include(u => u.Claims)
                .Include(u => u.UserRoles)
                    .ThenInclude(x => x.Role)
                .Where(x => x.Claims.Any(cl => cl.ClaimType == claimType && cl.ClaimValue == claimValue))
                .ToArrayAsync();
        }
    }
}
