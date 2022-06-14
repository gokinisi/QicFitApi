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
    public class AgeGroupService : BaseService, IAgeGroupService
    {
        protected readonly IAgeGroupRepository AgeGroupRepository;

        public AgeGroupService(ICurrentContextProvider contextProvider, IAgeGroupRepository AgeGroupRepository) : base(contextProvider)
        {
            this.AgeGroupRepository = AgeGroupRepository;
        }
        public async Task<IEnumerable<AgeGroupDTO>> GetAll()
        {
            var ageGroup = await AgeGroupRepository.GetList(Session);

            return ageGroup.MapTo<IEnumerable<AgeGroupDTO>>();
        }

        public async Task<AgeGroupDTO> GetById(int id)
        {
            var ageGroup = await AgeGroupRepository.Get(id, Session);

            return ageGroup.MapTo<AgeGroupDTO>();
        }

        public async Task<AgeGroupDTO> Update(AgeGroupDTO ageGroup)
        {
            var result = await AgeGroupRepository.Edit(ageGroup.MapTo<AgeGroup>(), Session);
            return result.MapTo<AgeGroupDTO>();
        }

        public async Task<AgeGroupDTO> Create(AgeGroupDTO ageGroup)
        {
            var result = await AgeGroupRepository.Edit(ageGroup.MapTo<AgeGroup>(), Session);
            return result.MapTo<AgeGroupDTO>();
        }

    }
}
