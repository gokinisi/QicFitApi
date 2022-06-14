using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Services
{
    public interface IWorkoutLocationService
    {
        Task<IEnumerable<WorkoutLocationDTO>> GetAll();
        Task<WorkoutLocationDTO> GetById(int id);

        // Task<IEnumerable<WorkoutLocationDTO>> GetByUser(int id);
        Task<IEnumerable<WorkoutCityGroupDTO>> GetByUser(int id);
        Task<WorkoutLocationDTO> Update(WorkoutLocationDTO location);
        Task<WorkoutLocationDTO> Create(WorkoutLocationDTO location);
    }
}
