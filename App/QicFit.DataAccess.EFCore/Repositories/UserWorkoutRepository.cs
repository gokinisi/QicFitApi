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
using QicFit.Entities.System;

namespace QicFit.DataAccess.EFCore.Repositories
{
    public class UserWorkoutRepository : BaseRepository<UserWorkout, QicFitDataContext>, IUserWorkoutRepository
    {
        public UserWorkoutRepository(QicFitDataContext context) : base(context)
        {
        }
        public override async Task<bool> Exists(UserWorkout obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.UserWorkouts.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<IEnumerable<UserWorkout>> GetList(ContextSession session)
        {
            var context = GetContext(session);

            var query = context.UserWorkouts.AsQueryable();

            return await query.ToArrayAsync();
        }

        public override async Task<UserWorkout> Get(int id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.UserWorkouts
                .Where(obj => obj.Id == id)
                .Include(w => w.Workout)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserWorkout>> GetWorkouts(ContextSession session)
        {
            var context = GetContext(session);

            var query = context.UserWorkouts
                .Where(obj => obj.UserId == session.UserId && obj.Workout.Date >= DateTime.Now)
                .Include(u => u.Workout)
                .ThenInclude(p => p.WorkoutLocation)
                .Include(a => a.Workout.AgeGroup)
                .Include(w => w.Workout.WorkoutType)
                .Include(g => g.Workout.Gender)
                .Include(f => f.Workout.FitnessLevel)
                .AsQueryable();

            return await query.ToArrayAsync();
        }

        public async Task<bool> UsersSignedUp(int id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.UserWorkouts.Where(x => x.WorkoutId == id).AsNoTracking().CountAsync() > 0;
  
        }
    }

}

