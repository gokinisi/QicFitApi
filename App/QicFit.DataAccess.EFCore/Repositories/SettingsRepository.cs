
using Common.Entities;
using Common.Services.Infrastructure;
using QicFit.DataAccess.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Common.DataAccess.EFCore
{
    public class SettingsRepository : BaseRepository<Settings, QicFitDataContext>, ISettingsRepository
    {
        public SettingsRepository(QicFitDataContext context) : base(context) { }

        public override async Task<bool> Exists(Settings obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Settings.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public override async Task<Settings> Get(int id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.Settings.Where(obj => obj.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}