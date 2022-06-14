using Common.Entities;
using QicFit.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Repositories
{
    public interface IWorkoutTypeRepository
    {
        Task<IEnumerable<WorkoutType>> GetList(ContextSession session);

        Task<WorkoutType> Get(int id, ContextSession session);

        Task<WorkoutType> Edit(WorkoutType workoutType, ContextSession session);


    }
}
