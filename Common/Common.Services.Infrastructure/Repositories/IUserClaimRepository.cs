
using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure
{
    public interface IUserClaimRepository<TUserClaim> where TUserClaim : BaseUserClaim
    {
        Task<IList<TUserClaim>> GetByUserId(int userId, ContextSession session);
        Task Delete(int userId, string claimType, string claimValue, ContextSession session);
        Task<TUserClaim> Add(TUserClaim userClaim, ContextSession session);
        Task<IList<TUserClaim>> EditMany(IList<TUserClaim> userClaims, ContextSession session);
        Task<IList<TUserClaim>> GetList(int userId, string claimType, string claimValue, ContextSession session);
    }
}
