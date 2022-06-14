using Common.Entities;
using QicFit.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Repositories
{
    public interface IAgeGroupRepository
    {
        Task<IEnumerable<AgeGroup>> GetList(ContextSession session);

        Task<AgeGroup> Get(int id, ContextSession session);

        Task<AgeGroup> Edit(AgeGroup ageGroup, ContextSession session);


    }
}
