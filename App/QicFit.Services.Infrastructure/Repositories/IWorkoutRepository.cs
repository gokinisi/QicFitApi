using Common.Entities;
using QicFit.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Repositories
{
    public interface IWorkoutRepository
    {
        Task<bool> Exists(Workout obj, ContextSession session);
        Task<IEnumerable<Workout>> GetList(ContextSession session);

        Task<Workout> Get(int id, ContextSession session);

        Task<IEnumerable<Workout>> GetWorkoutGroups(int days, ContextSession session);

        Task<Workout> Edit(Workout workout, ContextSession session);

        Task<Workout> Add(Workout workout, ContextSession session);

        Task Delete(int id, ContextSession session);

        Task<Workout> Search(Workout workout, ContextSession session);


    }
}
