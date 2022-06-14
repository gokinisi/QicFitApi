using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Services
{
    public interface IFitnessLevelService
    {
        Task<IEnumerable<FitnessLevelDTO>> GetAll();
        Task<FitnessLevelDTO> GetById(int id);
        Task<FitnessLevelDTO> Update(FitnessLevelDTO fitnessLevel);
        Task<FitnessLevelDTO> Create(FitnessLevelDTO fitnessLevel);
    }
}
