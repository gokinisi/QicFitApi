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
    public class StateService : BaseService, IStateService
    {
        protected readonly IStateRepository stateRepository;

        public StateService(ICurrentContextProvider contextProvider, IStateRepository stateRepository) : base(contextProvider)
        {
            this.stateRepository = stateRepository;
        }


        public async Task<IEnumerable<StateDTO>> GetAll()
        {
            var state = await stateRepository.GetList(Session);

            return state.MapTo<IEnumerable<StateDTO>>();
        }

        public async Task<StateDTO> GetById(int id)
        {
            var state = await stateRepository.Get(id, Session);

            return state.MapTo<StateDTO>();
        }
    }
}
