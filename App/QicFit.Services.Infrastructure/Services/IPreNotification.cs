using QicFit.DTO;
using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure.Services
{
    public interface IPreNotificationService
    {
        Task<IEnumerable<PreNotificationDTO>> GetAll();
        Task<PreNotificationDTO> GetById(int id);
        Task<PreNotificationDTO> UnsubscribeNotification(SubscriptionDTO subscription);
        Task<PreNotificationDTO> Update(PreNotificationDTO preNotification);
        Task<PreNotificationDTO> Create(PreNotificationDTO preNotification);
    }
}
