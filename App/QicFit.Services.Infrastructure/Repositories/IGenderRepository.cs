using Common.Entities;
using QicFit.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Repositories
{
    public interface IGenderRepository
    {
        Task<IEnumerable<Gender>> GetList(ContextSession session);

        Task<Gender> Get(int id, ContextSession session);

        Task<Gender> Edit(Gender gender, ContextSession session);


    }
}
