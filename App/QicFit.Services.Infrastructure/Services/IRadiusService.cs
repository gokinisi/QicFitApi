using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Services
{
    public interface IRadiusService
    {
        Task<IEnumerable<RadiusDTO>> GetAll();
        Task<RadiusDTO> GetById(int id);
        Task<RadiusDTO> Update(RadiusDTO radius);
        Task<RadiusDTO> Create(RadiusDTO radius);
    }
}
