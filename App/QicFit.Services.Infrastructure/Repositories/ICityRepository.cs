using Common.Entities;
using QicFit.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetList(ContextSession session);

        Task<City> Get(int id, ContextSession session);

        Task<IEnumerable<City>> Search(string predicate, ContextSession session);

    }
}
