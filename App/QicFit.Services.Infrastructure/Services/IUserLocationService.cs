using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Services
{
    public interface IUserLocationService
    {
        Task<IEnumerable<UserLocationDTO>> GetAll();
        Task<UserLocationDTO> GetById(int id);
        Task<UserLocationDTO> Update(UserLocationDTO location);
        Task<UserLocationDTO> Create(UserLocationDTO location);
    }
}
