using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Services
{
    public interface ISystemMessageService
    {
        Task<IEnumerable<SystemMessageDTO>> GetAll();
        Task<SystemMessageDTO> GetById(int id);
        Task<SystemMessageDTO> Update(SystemMessageDTO systemMessage);
        Task<SystemMessageDTO> Create(SystemMessageDTO systemMessage);
    }
}
