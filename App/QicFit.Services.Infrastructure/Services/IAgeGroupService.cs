using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Services
{
    public interface IAgeGroupService
    {
        Task<IEnumerable<AgeGroupDTO>> GetAll();
        Task<AgeGroupDTO> GetById(int id);
        Task<AgeGroupDTO> Update(AgeGroupDTO ageGroup);
        Task<AgeGroupDTO> Create(AgeGroupDTO ageGroup);
    }
}
