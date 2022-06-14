using Common.Entities;
using QicFit.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Repositories
{
    public interface IRadiusRepository
    {
        Task<IEnumerable<Radius>> GetList(ContextSession session);

        Task<Radius> Get(int id, ContextSession session);

        Task<Radius> Edit(Radius radius, ContextSession session);


    }
}
