using Common.Entities;
using QicFit.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Repositories
{
    public interface IWorkoutLocationRepository
    {
        Task<IEnumerable<WorkoutLocation>> GetList(ContextSession session);

        Task<WorkoutLocation> Get(int id, ContextSession session);

        Task<IEnumerable<WorkoutLocation>> GetByUser(int userId, ContextSession session);

        Task<WorkoutLocation> Edit(WorkoutLocation location, ContextSession session);
    }
}
