using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Services
{
    public interface IGenderService
    {
        Task<IEnumerable<GenderDTO>> GetAll();
        Task<GenderDTO> GetById(int id);
        Task<GenderDTO> Update(GenderDTO gender);
        Task<GenderDTO> Create(GenderDTO gender);
    }
}
