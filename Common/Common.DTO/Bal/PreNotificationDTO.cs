using System;
using System.Collections.Generic;
using System.Text;

namespace QicFit.DTO
{
    public class PreNotificationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string NotificationId { get; set; }
        public DateTime RegisteredDate { get; set; }
        public bool Unsubscribed { get; set; }
        public DateTime UnsubscribedDate { get; set; }
    }
}
