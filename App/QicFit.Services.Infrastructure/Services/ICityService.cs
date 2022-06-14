using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Services
{
    public interface ICityService
    {
        Task<IEnumerable<CityDTO>> GetAll();
        Task<CityDTO> GetById(int id);
        Task<IEnumerable<CityDTO>> Search(string predicate);
    }
}
