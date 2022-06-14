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

namespace QicFit.DataAccess.EFCore.Repositories
{
    public class WorkoutTypeRepository : BaseRepository<WorkoutType, QicFitDataContext>, IWorkoutTypeRepository
    {

        public WorkoutTypeRepository(QicFitDataContext context) : base(context)
        {
        }

        public override async Task<bool> Exists(WorkoutType obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.WorkoutType.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<IEnumerable<WorkoutType>> GetList(ContextSession session)
        {
            var context = GetContext(session);

            return await context.WorkoutType.Where(w => w.Active == true)
                .Include(f => f.FitnessLevels)
                .OrderBy(o => o.Order)
                .ToArrayAsync();
        }

        public override async Task<WorkoutType> Get(int id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.WorkoutType
                .Include(f => f.FitnessLevels)
                .Where(obj => obj.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
      
    }
}
