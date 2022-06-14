
using Common.Entities;
using QicFit.Entities.System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetList(BaseFilter filter, ContextSession session);
        Task<User> Get(int id, ContextSession session);
        Task<User> Edit(User order, ContextSession session);
        Task Delete(int id, ContextSession session);
        Task<IEnumerable<User>> GetByWorkout(int workoutId, ContextSession session);

    }
}
