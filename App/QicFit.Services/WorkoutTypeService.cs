using Common.Services;
using Common.Services.Infrastructure;
using Common.Utils;
using QicFit.DTO;
using QicFit.Entities;
using QicFit.Services.Infrastructure.Repositories;
using QicFit.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services
{
    public class WorkoutTypeService : BaseService, IWorkoutTypeService
    {
        protected readonly IWorkoutTypeRepository workoutTypeRepository;

        public WorkoutTypeService(ICurrentContextProvider contextProvider, IWorkoutTypeRepository workoutTypeRepository) : base(contextProvider)
        {
            this.workoutTypeRepository = workoutTypeRepository;
        }
        public async Task<IEnumerable<WorkoutTypeDTO>> GetAll()
        {
            var workoutType = await workoutTypeRepository.GetList(Session);

            return workoutType.MapTo<IEnumerable<WorkoutTypeDTO>>();
        }

        public async Task<WorkoutTypeDTO> GetById(int id)
        {
            var workoutType = await workoutTypeRepository.Get(id, Session);

            return workoutType.MapTo<WorkoutTypeDTO>();
        }

        public async Task<WorkoutTypeDTO> Update(WorkoutTypeDTO workoutType)
        {
             var result = await workoutTypeRepository.Edit(workoutType.MapTo<WorkoutType>(), Session);
            return result.MapTo<WorkoutTypeDTO>();
        }

        public async Task<WorkoutTypeDTO> Create(WorkoutTypeDTO workoutType)
        {
            var result = await workoutTypeRepository.Edit(workoutType.MapTo<WorkoutType>(), Session);
            return result.MapTo<WorkoutTypeDTO>();
        }
    }
}
