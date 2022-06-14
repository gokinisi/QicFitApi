using Common.DTO;
using Common.Services;
using Common.Services.Infrastructure;
using Common.Utils;
using Common.Utils.Extensions;
using QicFit.DTO;
using QicFit.Entities;
using QicFit.Services.Infrastructure;
using QicFit.Services.Infrastructure.Repositories;
using QicFit.Services.Infrastructure.Services;
using QicFit.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QicFit.Services
{
    public class WorkoutService : BaseService, IWorkoutService
    {
        protected readonly IWorkoutRepository workoutRepository;
        protected readonly IUserWorkoutRepository userWorkoutRepository;
        protected readonly IUserRepository userRepository;
        protected readonly IWorkoutLocationRepository locationRepository;
        protected readonly IWorkoutTypeRepository workoutTypeRepository;
        protected readonly IUserWorkoutService userWorkoutService;

        public WorkoutService(ICurrentContextProvider contextProvider, IWorkoutRepository workoutRepository,
            IUserWorkoutRepository userWorkoutRepository, IUserRepository userRepository,
            IWorkoutTypeRepository workoutTypeRepository, IWorkoutLocationRepository locationRepository,
             IUserWorkoutService userWorkoutService
            ) : base(contextProvider)
        {
            this.workoutRepository = workoutRepository;
            this.userWorkoutRepository = userWorkoutRepository;
            this.userRepository = userRepository;
            this.workoutTypeRepository = workoutTypeRepository;
            this.locationRepository = locationRepository;
            this.userWorkoutService = userWorkoutService;

        }
        public async Task<IEnumerable<WorkoutDTO>> GetAllWorkouts()
        {
            var workouts = await workoutRepository.GetList(Session);
            
            return workouts.MapTo<IEnumerable<WorkoutDTO>>();
        }

        public async Task<WorkoutDTO> GetById(int id)
        {
            var workout = await workoutRepository.Get(id, Session);
            var userResult = await userRepository.GetByWorkout(workout.Id, Session);

            var workoutDto = workout.MapTo<WorkoutDTO>();
            workoutDto.Participants = userResult.MapTo<IEnumerable<UserDTO>>(); 

            return workout.MapTo<WorkoutDTO>();
        }

        public async Task<WorkoutDTO> Update(WorkoutDTO workout)
        {
             var result = await workoutRepository.Edit(workout.MapTo<Workout>(), Session);
            return result.MapTo<WorkoutDTO>();
        }

        public async Task<WorkoutDTO> Create(WorkoutDTO workout)
        {
            try
            {
                var exists = await workoutRepository.Exists(workout.MapTo<Workout>(), Session);
                var existingWorkout = new Workout();

                if (!exists)
                {
                    var location = await locationRepository.Get(workout.WorkoutLocationId, Session);
                    var workoutType = await workoutTypeRepository.Get(workout.WorkoutTypeId, Session);

                    workout.RadiusId = 5; //temporary placeholder until radius is implemented
                    workout.Name = $"{workoutType.Name} at {location.Name}";
                    workout.Date = DateTimeExtensions.CreateDateTime(workout.Date, workout.Time);
                    //create the work out
                    existingWorkout = await workoutRepository.Add(workout.MapTo<Workout>(), Session);
                    workout = existingWorkout.MapTo<WorkoutDTO>();
                }

                //add the user to the workout
                var userWorkoutDto = new UserWorkoutDTO();
                userWorkoutDto.Workout = new WorkoutDTO() { Id = existingWorkout.Id };
 
 
               var userWorkout = await userWorkoutService.Create(userWorkoutDto);

               return workout;
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<WorkoutDTO> Search(WorkoutDTO workout)
        {
            workout.RadiusId = 5; //temporary placeholder until radius is implemented
            workout.Date = DateTimeExtensions.CreateDateTime(workout.Date, workout.Time);

            var workoutSearch = await workoutRepository.Search(workout.MapTo<Workout>(), Session);
            var workoutResult = new WorkoutDTO();

            if (workoutSearch != null)
            {
                workoutResult = workoutSearch.MapTo<WorkoutDTO>();
                //get users associated with the workout
                var userResult = await userRepository.GetByWorkout(workoutResult.Id, Session);
                workoutResult.Participants = userResult.MapTo<IEnumerable<UserDTO>>();

                var res = userResult.Where(i => i.Id == Session.UserId);

                if (res.Count() > 0)
                {
                    workoutResult.AlreadySignedUp = true;
                }
            }

            return workoutResult;
        }

        public async Task<IEnumerable<WorkoutGroupDTO>> GetWorkoutGroups(int days)
        {
   
            var workoutList = new List<WorkoutGroupDTO>();
 
            var workout = await workoutRepository.GetWorkoutGroups(days, Session);
            
            var workoutDto = workout.MapTo<IEnumerable<WorkoutDTO>>();

            var orderedWorkouts = workoutDto.OrderBy(w => w.Date).ToList();

            var group = orderedWorkouts.GroupBy(r => r.Date.Date).Select(r => r.First()).ToList();

            for (int i = 0; i < group.Count(); i++)
            {
                var item = group[i];
                var list = new List<WorkoutGroupDTO>();
  
                var w = new WorkoutGroupDTO();

                w.Id = i + 1;

                if (item.Date.Date == DateTime.Now.Date)
                {
                    w.Title = "Today";
                }
                else if (item.Date.Date == DateTime.Now.AddDays(1).Date)
                {
                    w.Title = "Tomorrow";
                }
                else
                {
                    w.Title = item.Date.ToString("MM/dd/yyyy");
                }

                w.Workouts = orderedWorkouts.Where(d => d.Date.Date == item.Date.Date);

                workoutList.Add(w);
            }

            return workoutList;
        }
    }
}
