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
    public class FitnessLevelRepository : BaseRepository<FitnessLevel, QicFitDataContext>, IFitnessLevelRepository
    {
        public FitnessLevelRepository(QicFitDataContext context) : base(context)
        {
        }
        public override async Task<bool> Exists(FitnessLevel obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Gender.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<IEnumerable<FitnessLevel>> GetList(ContextSession session)
        {
            var context = GetContext(session);

            return await context.FitnessLevel.OrderBy(o => o.Order).ToArrayAsync();
        }

        public override async Task<FitnessLevel> Get(int id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.FitnessLevel
                .Where(obj => obj.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        
    }
}
