using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Services
{
    public interface IStateService
    {
        Task<IEnumerable<StateDTO>> GetAll();
        Task<StateDTO> GetById(int id);
    }
}
