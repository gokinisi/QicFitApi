using Common.Services;
using Common.Services.Infrastructure;
using Common.Utils;
using QicFit.DTO;
using QicFit.Entities;
using QicFit.Services.Infrastructure.Repositories;
using QicFit.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services
{
    public class UserLocationService : BaseService, IUserLocationService
    {
        protected readonly IUserLocationRepository locationRepository;

        public UserLocationService(ICurrentContextProvider contextProvider, IUserLocationRepository locationRepository) : base(contextProvider)
        {
            this.locationRepository = locationRepository;
        }
        public async Task<IEnumerable<UserLocationDTO>> GetAll()
        {
            var locations = await locationRepository.GetList(Session);

            return locations.MapTo<IEnumerable<UserLocationDTO>>();
        }

        public async Task<UserLocationDTO> GetById(int id)
        {
            var location = await locationRepository.Get(id, Session);

            return location.MapTo<UserLocationDTO>();
        }

        public async Task<UserLocationDTO> Update(UserLocationDTO location)
        {
            var result = await locationRepository.Edit(location.MapTo<UserLocation>(), Session);
            return result.MapTo<UserLocationDTO>();
        }

        public async Task<UserLocationDTO> Create(UserLocationDTO location)
        {
            try
            {
                var result = await locationRepository.Edit(location.MapTo<UserLocation>(), Session);
                return result.MapTo<UserLocationDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}
