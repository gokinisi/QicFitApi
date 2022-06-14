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
    public class PreNotificationRepository : BaseRepository<PreNotification, QicFitDataContext>, IPreNotificationRepository
    {
        public PreNotificationRepository(QicFitDataContext context) : base(context)
        {
        }

        public override async Task<bool> Exists(PreNotification obj, ContextSession session)
        {
            var context = GetContext(session);
            return await context.PreNotification.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public async Task<IEnumerable<PreNotification>> GetList(ContextSession session)
        {
            var context = GetContext(session);

            var query = context.PreNotification.AsQueryable();

            return await query.ToArrayAsync();
        }

        public async override Task<PreNotification> Get(int id, ContextSession session)
        {
            var context = GetContext(session);
            return await context.PreNotification
                .Where(obj => obj.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<PreNotification> GetByNotificationId(string notificationId, ContextSession session)
        {
            var context = GetContext(session);
            return await context.PreNotification
                .Where(obj => obj.NotificationId == notificationId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
