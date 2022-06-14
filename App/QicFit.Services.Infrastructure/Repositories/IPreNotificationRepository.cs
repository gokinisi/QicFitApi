using Common.Entities;
using QicFit.Entities;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Repositories
{
    public interface IPreNotificationRepository
    {
        Task<IEnumerable<PreNotification>> GetList(ContextSession session);

        Task<PreNotification> Get(int id, ContextSession session);
        Task<PreNotification> GetByNotificationId(string notificationId, ContextSession session);

        Task<PreNotification> Edit(PreNotification preNotification, ContextSession session);

    }
}
