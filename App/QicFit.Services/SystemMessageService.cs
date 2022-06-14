using Common.Entities;
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
    public class SystemMessageService : BaseService, ISystemMessageService
    {
        protected readonly ISystemMessageRepository systemMessageRepository;

        public SystemMessageService(ICurrentContextProvider contextProvider, 
                                    ISystemMessageRepository systemMessageRepository) : base(contextProvider)
        {
            this.systemMessageRepository = systemMessageRepository;
        }

        public async Task<IEnumerable<SystemMessageDTO>> GetAll()
        {
            var systemMessage = await systemMessageRepository.GetList(Session);

            return systemMessage.MapTo<IEnumerable<SystemMessageDTO>>();
        }

        public async Task<SystemMessageDTO> GetById(int id)
        {
            var systemMessage = await systemMessageRepository.Get(id, Session);

            return systemMessage.MapTo<SystemMessageDTO>();
        }

        public async Task<SystemMessageDTO> Update(SystemMessageDTO systemMessage)
        {
            var result = await systemMessageRepository.Edit(systemMessage.MapTo<SystemMessage>(), Session);
            return result.MapTo<SystemMessageDTO>();
        }

        public async Task<SystemMessageDTO> Create(SystemMessageDTO systemMessage)
        {
            try
            {
                var result = await systemMessageRepository.Edit(systemMessage.MapTo<SystemMessage>(), Session);
                return result.MapTo<SystemMessageDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
