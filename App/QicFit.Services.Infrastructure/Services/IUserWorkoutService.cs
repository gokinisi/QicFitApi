using QicFit.DTO;
using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Services
{
    public interface IUserWorkoutService
    {
        Task<IEnumerable<UserWorkoutDTO>> GetWorkouts();

        Task<IEnumerable<UserWorkoutGroupDTO>> GetWorkoutGroups();

        Task<UserWorkoutDTO> Create(UserWorkoutDTO userWorkout);

        Task Remove(int id);
    }
}
