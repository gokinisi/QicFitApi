using Common.DataAccess.EFCore;
using QicFit.Entities;
using QicFit.Services.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QicFit.DataAccess.EFCore.Repositories
{
    public class WorkoutLocationRequirementRepository : BaseRepository<WorkoutLocationRequirement, QicFitDataContext>, IWorkoutLocationRequirementRepository
    {
        public WorkoutLocationRequirementRepository(QicFitDataContext context) : base(context)
        {
        }
        public override async Task<bool> Exists(WorkoutLocationRequirement obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.WorkoutLocationRequirement.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<IEnumerable<WorkoutLocationRequirement>> GetList(ContextSession session)
        {
            var context = GetContext(session);

            var query = context.WorkoutLocationRequirement.AsQueryable();

            return await query.ToArrayAsync();
        }

        public override async Task<WorkoutLocationRequirement> Get(int id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.WorkoutLocationRequirement
                .Where(obj => obj.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

    }
}
