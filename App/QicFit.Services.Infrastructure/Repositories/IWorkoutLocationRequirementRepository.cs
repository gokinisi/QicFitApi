using Common.Entities;
using QicFit.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Repositories
{
    public interface IWorkoutLocationRequirementRepository
    {
        Task<IEnumerable<WorkoutLocationRequirement>> GetList(ContextSession session);

        Task<WorkoutLocationRequirement> Get(int id, ContextSession session);

        Task<WorkoutLocationRequirement> Edit(WorkoutLocationRequirement locationRequirement, ContextSession session);


    }
}
