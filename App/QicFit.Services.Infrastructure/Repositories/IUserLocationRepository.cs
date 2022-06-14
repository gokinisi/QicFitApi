using Common.Entities;
using QicFit.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Repositories
{
    public interface IUserLocationRepository
    {
        Task<IEnumerable<UserLocation>> GetList(ContextSession session);

        Task<UserLocation> Get(int id, ContextSession session);

        Task<UserLocation> Edit(UserLocation location, ContextSession session);
    }
}
