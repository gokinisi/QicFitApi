
using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure
{
    public interface IIdentityUserRepository<TUser> where TUser : BaseUser
    {
        Task Delete(int id, ContextSession session);
        Task<TUser> GetById(int id, ContextSession session);
        Task<TUser> GetByUserName(string username, ContextSession session);
        Task<IList<TUser>> GetUsersByRole(int roleId, ContextSession session);
        Task<IList<TUser>> GetUsersByClaim(string claimType, string claimValue, ContextSession session);
        Task<TUser> GetByEmail(string email, ContextSession session);
        Task<TUser> Edit(TUser user, ContextSession session);
    }
}
