using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Services
{

    public interface IWorkoutTypeService
    {
        Task<IEnumerable<WorkoutTypeDTO>> GetAll();
        Task<WorkoutTypeDTO> GetById(int id);
        Task<WorkoutTypeDTO> Update(WorkoutTypeDTO workoutType);
        Task<WorkoutTypeDTO> Create(WorkoutTypeDTO workoutType);
    }
}
