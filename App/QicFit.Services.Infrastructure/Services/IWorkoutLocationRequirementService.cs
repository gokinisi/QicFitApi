using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Services
{
    public interface IWorkoutLocationRequirementService
    {
        Task<IEnumerable<WorkoutLocationRequirementDTO>> GetAll();
        Task<WorkoutLocationRequirementDTO> GetById(int id);
        Task<WorkoutLocationRequirementDTO> Update(WorkoutLocationRequirementDTO locationRequirement);
        Task<WorkoutLocationRequirementDTO> Create(WorkoutLocationRequirementDTO locationRequirement);
    }
}
