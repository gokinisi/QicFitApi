using Common.Entities;
using QicFit.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Repositories
{
    public interface IUserWorkoutRepository
    {
        Task<IEnumerable<UserWorkout>> GetList(ContextSession session);

        Task<UserWorkout> Get(int id, ContextSession session);

        Task<UserWorkout> Edit(UserWorkout userWorkout, ContextSession session);

        Task<IEnumerable<UserWorkout>> GetWorkouts(ContextSession session);

        Task<bool> UsersSignedUp(int id, ContextSession session);

        Task Delete(int id, ContextSession session);
    }
}
