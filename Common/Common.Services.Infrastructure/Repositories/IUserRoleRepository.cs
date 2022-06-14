
using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure
{
    public interface IUserRoleRepository<TUserRole> where TUserRole : BaseUserRole
    {
        Task<TUserRole> Add(TUserRole userRole, ContextSession session);
        Task<TUserRole> Get(int userId, int roleId, ContextSession session);
        Task Delete(int userId, int roleId, ContextSession session);
        Task<IList<string>> GetByUserId(int userId, ContextSession session);
    }
}
