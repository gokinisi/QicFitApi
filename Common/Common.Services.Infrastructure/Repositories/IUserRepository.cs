
using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure
{
    public interface IUserRepository<TUser> where TUser : BaseUser
    {
        Task Delete(int id, ContextSession session);
        Task<(IEnumerable<TUser>, int)> GetFilteredListWithTotalCount(UsersGridFilter filter, ContextSession session);
        Task<TUser> GetByUserName(string username, ContextSession session);
        Task<TUser> GetByEmail(string email, ContextSession session);
        Task<TUser> Get(int id, ContextSession session);
        Task<TUser> Edit(TUser user, ContextSession session);
    }
}
