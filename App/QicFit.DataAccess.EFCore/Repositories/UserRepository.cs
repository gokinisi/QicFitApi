
using Common.DataAccess.EFCore;
using Common.Entities;
using QicFit.Entities.System;
using QicFit.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QicFit.DataAccess.EFCore
{
    public class UserRepository : BaseUserRepository<User, QicFitDataContext>, IUserRepository
    {
        public UserRepository(QicFitDataContext context) : base(context)
        {
        }

        public Task<IEnumerable<User>> GetList(BaseFilter filter, ContextSession session)
        {
            throw new System.NotImplementedException();
        }
        public async Task<IEnumerable<User>> GetByWorkout(int workoutId, ContextSession session)
        {
            var context = GetContext(session);

            var query = context.Users
                        .Where(obj => obj.UserWorkout
                        .Any(c => c.WorkoutId == workoutId))
                        .Include(g => g.Gender)
                        .Select(f => new User()
                        {
                            Id = f.Id,
                            FirstName = f.FirstName,
                            Gender = f.Gender
                        })
                        .AsQueryable();

            return await query.ToArrayAsync();
        }
    }
    
}