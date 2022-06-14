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
    public class FitnessLevelService : BaseService, IFitnessLevelService
    {
        protected readonly IFitnessLevelRepository fitnessLevelRepository;

        public FitnessLevelService(ICurrentContextProvider contextProvider, 
                                   IFitnessLevelRepository fitnessLevelRepository) : base(contextProvider)
        {
            this.fitnessLevelRepository = fitnessLevelRepository;
        }
        public async Task<IEnumerable<FitnessLevelDTO>> GetAll()
        {
            var fitnessLevel = await fitnessLevelRepository.GetList(Session);

            return fitnessLevel.MapTo<IEnumerable<FitnessLevelDTO>>();
        }

        public async Task<FitnessLevelDTO> GetById(int id)
        {
            var fitnessLevel = await fitnessLevelRepository.Get(id, Session);

            return fitnessLevel.MapTo<FitnessLevelDTO>();
        }

        public async Task<FitnessLevelDTO> Update(FitnessLevelDTO fitnessLevel)
        {
            var result = await fitnessLevelRepository.Edit(fitnessLevel.MapTo<FitnessLevel>(), Session);
            return result.MapTo<FitnessLevelDTO>();
        }

        public async Task<FitnessLevelDTO> Create(FitnessLevelDTO fitnessLevel)
        {
            var result = await fitnessLevelRepository.Edit(fitnessLevel.MapTo<FitnessLevel>(), Session);
            return result.MapTo<FitnessLevelDTO>();
        }

    }
}
