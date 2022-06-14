using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Services
{
    public interface IWorkoutService
    {
        Task<IEnumerable<WorkoutDTO>> GetAllWorkouts();
        Task<IEnumerable<WorkoutGroupDTO>> GetWorkoutGroups(int days);
        Task<WorkoutDTO> GetById(int id);
        Task<WorkoutDTO> Update(WorkoutDTO workout);
        Task<WorkoutDTO> Create(WorkoutDTO workout);
        Task<WorkoutDTO> Search(WorkoutDTO workout);
    }
}
