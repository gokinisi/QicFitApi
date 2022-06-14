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
    public class WorkoutLocationRequirementService : BaseService, IWorkoutLocationRequirementService
    {
        protected readonly IWorkoutLocationRequirementRepository LocationRequirementRepository;

        public WorkoutLocationRequirementService(ICurrentContextProvider contextProvider, IWorkoutLocationRequirementRepository LocationRequirementRepository) : base(contextProvider)
        {
            this.LocationRequirementRepository = LocationRequirementRepository;
        }
        public async Task<IEnumerable<WorkoutLocationRequirementDTO>> GetAll()
        {
            var requirements = await LocationRequirementRepository.GetList(Session);

            return requirements.MapTo<IEnumerable<WorkoutLocationRequirementDTO>>();
        }

        public async Task<WorkoutLocationRequirementDTO> GetById(int id)
        {
            var requirement = await LocationRequirementRepository.Get(id, Session);

            return requirement.MapTo<WorkoutLocationRequirementDTO>();
        }

        public async Task<WorkoutLocationRequirementDTO> Update(WorkoutLocationRequirementDTO requirement)
        {
            var result = await LocationRequirementRepository.Edit(requirement.MapTo<WorkoutLocationRequirement>(), Session);
            return result.MapTo<WorkoutLocationRequirementDTO>();
        }

        public async Task<WorkoutLocationRequirementDTO> Create(WorkoutLocationRequirementDTO requirement)
        {
            var result = await LocationRequirementRepository.Edit(requirement.MapTo<WorkoutLocationRequirement>(), Session);
            return result.MapTo<WorkoutLocationRequirementDTO>();
        }

    }
}
