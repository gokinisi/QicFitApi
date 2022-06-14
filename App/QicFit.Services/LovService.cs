using Common.Services;
using Common.Services.Infrastructure;
using Common.Utils;
using QicFit.DTO;
using QicFit.Services.Infrastructure.Services;
using System.Collections.Generic;
using System.Linq;

namespace QicFit.Services
{
    public class LovService : BaseService, ILovService
    {
        protected readonly IGenderService genderService;
        protected readonly IAgeGroupService ageGroupService;
        protected readonly IWorkoutLocationService workoutLocationService;
        protected readonly IRadiusService radiusService;
        protected readonly IWorkoutTypeService workoutTypeService;
        protected readonly ICityService cityService;
        protected readonly IStateService stateService;

        public LovService(ICurrentContextProvider contextProvider, 
                          IGenderService genderService,
                          IAgeGroupService ageGroupService,
                          IWorkoutLocationService workoutLocationService,
                          IRadiusService radiusService,
                          IWorkoutTypeService workoutTypeService,
                          ICityService cityService,
                          IStateService stateService) : base(contextProvider)
        {
            this.genderService = genderService;
            this.ageGroupService = ageGroupService;
            this.workoutLocationService = workoutLocationService;
            this.radiusService = radiusService;
            this.workoutTypeService = workoutTypeService;
            this.cityService = cityService;
            this.stateService = stateService;
        }

        public LovDTO GetAll()
        {
            var lov = new LovDTO();

            lov.GenderLOV = genderService.GetAll().Result;
            lov.AgeGroupLOV = ageGroupService.GetAll().Result;
            //lov.LocationLOV = workoutLocationService.GetAll().Result;
            lov.RadiusLOV = radiusService.GetAll().Result;
            lov.WorkoutTypeLOV = workoutTypeService.GetAll().Result;
            lov.CityLOV = cityService.GetAll().Result;
            lov.StateLOV = stateService.GetAll().Result;

            return lov;
        }

        public LovDTO GetWorkoutLocationsLov(int userId)
        {
            var lov = new LovDTO();

            lov.WorkoutLocationLOV = workoutLocationService.GetByUser(userId).Result;

            return lov;

        }

       
    }
}
