using Common.DataAccess.EFCore;
using QicFit.Entities;
using QicFit.Services.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Common.Utils.Extensions;

namespace QicFit.DataAccess.EFCore.Repositories
{
    public class WorkoutRepository : BaseRepository<Workout, QicFitDataContext>, IWorkoutRepository
    {

        public WorkoutRepository(QicFitDataContext context) : base(context)
        {
        }

        public override async Task<bool> Exists(Workout 
            obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Workouts.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<IEnumerable<Workout>> GetList(ContextSession session)
        {
            var context = GetContext(session);
            
            var query = context.Workouts.AsQueryable();

            return await query.ToArrayAsync();
        }

        public override async Task<Workout> Get(int id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Workouts
                .Where(obj => obj.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Workout> Add(Workout workout, ContextSession session)
        {
            var context = GetContext(session);
            
            context.Add(workout);
            await context.SaveChangesAsync();

            return workout;
        }

        public async Task<Workout> Search(Workout workout, ContextSession session)
        {
            var date = workout.Date.ToString("MM/dd/yyyy HH:mm:ss");
            var time = workout.Time.ToString("MM/dd/yyyy HH:mm:ss");

            var convertedDate = Convert.ToDateTime(date);
            var convertedTime = Convert.ToDateTime(time);

            var fromTime = new DateTime(convertedDate.Year, convertedDate.Month, convertedDate.Day,
                                        convertedTime.Hour, convertedTime.Minute, convertedTime.Second);
            

            var context = GetContext(session);
            return await context.Workouts
                .Include(l => l.WorkoutLocation)
                .Include(u => u.UserWorkout)
                .Where(obj => obj.GenderId == workout.GenderId &&
                       obj.FitnessLevelId == workout.FitnessLevelId &&
                       obj.WorkoutTypeId == workout.WorkoutTypeId && 
                       obj.WorkoutLocationId == workout.WorkoutLocationId &&
                       obj.RadiusId == workout.RadiusId &&
                       obj.Date == convertedDate &&
                       obj.Time == fromTime
                       )
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Workout>> GetWorkoutGroups(int days, ContextSession session)
        {
            var context = GetContext(session);

            var maxDate = DateTime.Now.AddDays(days);

            maxDate = DateTimeExtensions.ResetTimeToEndOfDay(maxDate);
 
            var now = DateTime.Now;

            var excludeWorkouts = (from w in context.Workouts
                                   join uw in context.UserWorkouts on w.Id equals uw.WorkoutId
                                   where uw.UserId == session.UserId
                                   select w.Id).ToList();

            var query = (
             from w in context.Workouts
             join wl in context.WorkoutLocations on w.WorkoutLocationId equals wl.Id
             join ag in context.AgeGroups on w.AgeGroupId equals ag.Id
             join wt in context.WorkoutType on w.WorkoutTypeId equals wt.Id
             join g in context.Gender on w.GenderId equals g.Id
             join f in context.FitnessLevel on w.FitnessLevelId equals f.Id
             join uw in context.UserWorkouts on w.Id equals uw.WorkoutId
             where w.Date > now && w.Date <= maxDate && !excludeWorkouts.Contains(w.Id)

             select new Workout
             {
                 Id = w.Id,
                 Name = w.Name,
                 Date = w.Date,
                 Time = w.Time,
                 CreatedByUserId = w.CreatedByUserId,
                 CreatedDate = w.CreatedDate,
                 UpdatedByUserId = w.UpdatedByUserId,
                 UpdatedDate = w.UpdatedDate,
                 GenderId = w.GenderId,
                 Gender = w.Gender,
                 AgeGroupId = w.AgeGroupId,
                 AgeGroup = w.AgeGroup,
                 WorkoutTypeId = w.WorkoutTypeId,
                 WorkoutType = w.WorkoutType,
                 WorkoutLocationId = w.WorkoutLocationId,
                 WorkoutLocation = w.WorkoutLocation,
                 FitnessLevelId = w.FitnessLevelId,
                 FitnessLevel = w.FitnessLevel,
             }) ;

            return await query.AsNoTracking().ToArrayAsync();

        }
    }
}
