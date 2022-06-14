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
    public class GenderService : BaseService, IGenderService
    {
        protected readonly IGenderRepository genderRepository;

        public GenderService(ICurrentContextProvider contextProvider, IGenderRepository genderRepository) : base(contextProvider)
        {
            this.genderRepository = genderRepository;
        }
        public async Task<IEnumerable<GenderDTO>> GetAll()
        {
            var gender = await genderRepository.GetList(Session);

            return gender.MapTo<IEnumerable<GenderDTO>>();
        }

        public async Task<GenderDTO> GetById(int id)
        {
            var gender = await genderRepository.Get(id, Session);

            return gender.MapTo<GenderDTO>();
        }

        public async Task<GenderDTO> Update(GenderDTO gender)
        {
            var result = await genderRepository.Edit(gender.MapTo<Gender>(), Session);
            return result.MapTo<GenderDTO>();
        }

        public async Task<GenderDTO> Create(GenderDTO gender)
        {
            var result = await genderRepository.Edit(gender.MapTo<Gender>(), Session);
            return result.MapTo<GenderDTO>();
        }

    }
}
