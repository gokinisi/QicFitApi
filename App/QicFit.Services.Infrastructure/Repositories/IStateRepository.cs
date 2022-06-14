using Common.Entities;
using QicFit.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Repositories
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetList(ContextSession session);

        Task<State> Get(int id, ContextSession session);

    }
}
