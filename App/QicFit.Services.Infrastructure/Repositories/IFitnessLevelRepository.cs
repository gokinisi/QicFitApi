using Common.Entities;
using QicFit.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Repositories
{
    public interface IFitnessLevelRepository
    {
        Task<IEnumerable<FitnessLevel>> GetList(ContextSession session);

        Task<FitnessLevel> Get(int id, ContextSession session);

        Task<FitnessLevel> Edit(FitnessLevel fitnessLevel, ContextSession session);


    }
}
