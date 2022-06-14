using Common.DTO;
using Common.Services;
using Common.Services.Infrastructure;
using Common.Utils;
using QicFit.DTO;
using QicFit.Entities;
using QicFit.Services.Infrastructure;
using QicFit.Services.Infrastructure.Repositories;
using QicFit.DTO;
using QicFit.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services
{
    public class UserWorkoutService : BaseService, IUserWorkoutService
    {
        protected readonly IUserWorkoutRepository userWorkoutRepository;
        protected readonly IWorkoutRepository workoutRepository;

        public UserWorkoutService(ICurrentContextProvider contextProvider, 
                                  IUserWorkoutRepository userWorkoutRepository,
                                  IWorkoutRepository workoutRepository) : base(contextProvider)
        {
            this.userWorkoutRepository = userWorkoutRepository;
            this.workoutRepository = workoutRepository;
        }
        public async Task<IEnumerable<UserWorkoutDTO>> GetWorkouts()
        {
            var workouts = await userWorkoutRepository.GetWorkouts(Session);

            workouts = workouts.OrderBy(r => r.Workout.Date);

            return workouts.MapTo<IEnumerable<UserWorkoutDTO>>();
        }

        public async Task<UserWorkoutDTO> GetById(int id)
        {
            var workout = await userWorkoutRepository.Get(id, Session);

            return workout.MapTo<UserWorkoutDTO>();
        }

        public async Task Remove(int id)
        {
            var userWorkout = GetById(id).Result;

            await userWorkoutRepository.Delete(id, Session);
    
            //remove the workout if the no users are registered
            var usersExists = await userWorkoutRepository.UsersSignedUp(userWorkout.Workout.Id, Session);
            
            if(!usersExists)
            {
                await workoutRepository.Delete(userWorkout.Workout.Id, Session);
            }
        }

        public async Task<UserWorkoutDTO> Create(UserWorkoutDTO userWorkout)
        {
            userWorkout.UserId = Session.UserId;

            var res = await userWorkoutRepository.Edit(userWorkout.MapTo<UserWorkout>(), Session);

            return res.MapTo<UserWorkoutDTO>(); ;
        }

        public async Task<IEnumerable<UserWorkoutGroupDTO>> GetWorkoutGroups()
        {
            var userWorkout = await userWorkoutRepository.GetWorkouts(Session);
            var workoutDto = userWorkout.MapTo<IEnumerable<UserWorkoutDTO>>();

            var orderedWorkouts = workoutDto.OrderBy(w => w.Workout.Date).ToList();

            var workoutList = new List<UserWorkoutGroupDTO>();
            var group = orderedWorkouts.GroupBy(r => r.Workout.Date.Date)
                                  .Select(r => r.First());

            foreach (var item  in group)
            {
                var uwg = new UserWorkoutGroupDTO();

                uwg.Id = item.Id;
  
                if (item.Workout.Date.Date == DateTime.Now.Date)
                {
                    uwg.WorkoutGroup.Title = "Today";
                }
                else if (item.Workout.Date.Date == DateTime.Now.AddDays(1).Date)
                {
                    uwg.WorkoutGroup.Title = "Tomorrow";
                }
                else
                {
                    uwg.WorkoutGroup.Title = item.Workout.Date.ToString("MM/dd/yyyy");
                }

                uwg.WorkoutGroup.Workouts = orderedWorkouts.Where(d => d.Workout.Date.Date == item.Workout.Date.Date)
                                             .Select(w => w.Workout)
                                             .OrderBy(w => w.Date);
                workoutList.Add(uwg);
            }

            return workoutList;
        }
    }
}

