using Common.Entities;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Repositories
{
    public interface ISystemMessageRepository
    {
        Task<IEnumerable<SystemMessage>> GetList(ContextSession session);

        Task<SystemMessage> Get(int id, ContextSession session);

        Task<SystemMessage> Edit(SystemMessage systemMessage, ContextSession session);

    }
}
