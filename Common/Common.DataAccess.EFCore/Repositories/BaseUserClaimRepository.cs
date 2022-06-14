
using Common.Entities;
using Common.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.DataAccess.EFCore
{
    public abstract class BaseUserClaimRepository<TUserClaim, TContext> : IUserClaimRepository<TUserClaim>
        where TUserClaim : BaseUserClaim, new()
        where TContext : CommonDataContext
    {
        private TContext dbContext;

        public BaseUserClaimRepository(TContext context)
        {
            dbContext = context;
        }

        protected TContext GetContext(ContextSession session)
        {
            dbContext.Session = session;
            return dbContext;
        }

        public async Task<TUserClaim> Add(TUserClaim userClaim, ContextSession session)
        {
            var context = GetContext(session);

            context.Entry(userClaim).State = EntityState.Added;
            await context.SaveChangesAsync();
            return userClaim;
        }

        public async Task<IList<TUserClaim>> EditMany(IList<TUserClaim> userClaims, ContextSession session)
        {
            var context = GetContext(session);

            foreach (var uc in userClaims)
            {
                context.Entry(uc).State = EntityState.Modified;
            }
            
            await context.SaveChangesAsync();

            return userClaims;
        }

        public async Task Delete(int userId, string claimType, string claimValue, ContextSession session)
        {
            var context = GetContext(session);

            var itemsToDelete = await context.Set<TUserClaim>().Where(cl => cl.UserId == userId && cl.ClaimType == claimType && cl.ClaimValue == claimValue).ToListAsync();
            context.Set<TUserClaim>().RemoveRange(itemsToDelete);
            await context.SaveChangesAsync();
        }

        public async Task<IList<TUserClaim>> GetByUserId(int userId, ContextSession session)
        {
            var context = GetContext(session);

            var list = await context.Set<TUserClaim>()
                    .AsNoTracking()
                    .Where(obj => obj.UserId == userId)
                    .ToListAsync();

            return list.ToList();
        }

        public async Task<IList<TUserClaim>> GetList(int userId, string claimType, string claimValue, ContextSession session)
        {
            var context = GetContext(session);

            var list = await context.Set<TUserClaim>()
                .AsNoTracking()
                .Where(obj => obj.UserId == userId && obj.ClaimType == claimType && obj.ClaimValue == claimValue)
                .ToListAsync();

            return list.ToList();
        }
    }
}
