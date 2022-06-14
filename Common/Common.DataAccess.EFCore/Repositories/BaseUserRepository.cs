
using Common.Entities;
using Common.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.DataAccess.EFCore
{
    public abstract class BaseUserRepository<TUser, TContext> : BaseRepository<TUser, TContext>, IUserRepository<TUser>
        where TUser : BaseUser, new()
        where TContext : CommonDataContext
    {
        public BaseUserRepository(TContext context) : base(context) { }

        public override async Task<bool> Exists(TUser obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Set<TUser>().Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public override async Task<TUser> Edit(TUser obj, ContextSession session)
        {
            var objectExists = await Exists(obj, session);
            var context = GetContext(session);
            context.Entry(obj).State = objectExists ? EntityState.Modified : EntityState.Added;

            if (string.IsNullOrEmpty(obj.Password))
            {
                context.Entry(obj).Property(x => x.Password).IsModified = false;
            }
            await context.SaveChangesAsync();
            return obj;
        }

        public override async Task<TUser> Get(int id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Set<TUser>()
                   .Where(obj => obj.Id == id)
                   .Include(u => u.UserRoles)
                       .ThenInclude(x => x.Role)
                   //.Include(u => u.Settings)
                   .AsNoTracking()
                   .FirstOrDefaultAsync();
        }

        public async Task<TUser> GetByUserName(string username, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Set<TUser>()
                    .Where(obj => obj.UserName == username)
                    .Include(u => u.UserRoles)
                        .ThenInclude(x => x.Role)
                    //.Include(u => u.Settings)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
        }

        public async Task<TUser> GetByEmail(string email, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Set<TUser>()
                    .Where(obj => obj.Email == email)
                    .Include(u => u.UserRoles)
                        .ThenInclude(x => x.Role)
                    //.Include(u => u.Settings)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
        }

        public async Task<(IEnumerable<TUser>, int)> GetFilteredListWithTotalCount(UsersGridFilter filter, ContextSession session)
        {
            var context = GetContext(session);
            return (
                    await context.Set<TUser>()
                        .AsNoTracking()
                        .Include(u => u.UserRoles)
                            .ThenInclude(x => x.Role)
                        //.Include(u => u.Settings)
                        .OrderByDescending(obj => obj.FirstName)
                        .Skip(filter.PageSize * (filter.PageNumber - 1))
                        .Take(filter.PageSize)
                        .ToArrayAsync(),
                    await context.Set<TUser>()
                        .AsNoTracking()
                        .CountAsync());
        }
    }
}
