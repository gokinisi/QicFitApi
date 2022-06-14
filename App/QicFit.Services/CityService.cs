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
    public class CityService : BaseService, ICityService
    {
        protected readonly ICityRepository cityRepository;

        public CityService(ICurrentContextProvider contextProvider, ICityRepository cityRepository) : base(contextProvider)
        {
            this.cityRepository = cityRepository;
        }

        public async Task<IEnumerable<CityDTO>> GetAll()
        {
            var city = await cityRepository.GetList(Session);

            return city.MapTo<IEnumerable<CityDTO>>();
        }

        public async Task<CityDTO> GetById(int id)
        {
            var city = await cityRepository.Get(id, Session);

            return city.MapTo<CityDTO>();
        }

        public async Task<IEnumerable<CityDTO>> Search(string predicate)
        {
            var cities = await cityRepository.Search(predicate, Session);

            return cities.MapTo<IEnumerable<CityDTO>>();
        }
    }
}
