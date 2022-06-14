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
    public class RadiusService : BaseService, IRadiusService
    {
        protected readonly IRadiusRepository RadiusRepository;

        public RadiusService(ICurrentContextProvider contextProvider, IRadiusRepository RadiusRepository) : base(contextProvider)
        {
            this.RadiusRepository = RadiusRepository;
        }
        public async Task<IEnumerable<RadiusDTO>> GetAll()
        {
            var radius = await RadiusRepository.GetList(Session);

            return radius.MapTo<IEnumerable<RadiusDTO>>();
        }

        public async Task<RadiusDTO> GetById(int id)
        {
            var radius = await RadiusRepository.Get(id, Session);

            return radius.MapTo<RadiusDTO>();
        }

        public async Task<RadiusDTO> Update(RadiusDTO radius)
        {
            var result = await RadiusRepository.Edit(radius.MapTo<Radius>(), Session);
            return result.MapTo<RadiusDTO>();
        }

        public async Task<RadiusDTO> Create(RadiusDTO radius)
        {
            var result = await RadiusRepository.Edit(radius.MapTo<Radius>(), Session);
            return result.MapTo<RadiusDTO>();
        }

    }
}
