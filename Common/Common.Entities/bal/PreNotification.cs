using Common.Entities;
using System;
using System.Collections.Generic;

namespace QicFit.Entities
{
    public class PreNotification : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string NotificationId { get; set; }
        public DateTime RegisteredDate { get; set; }
        public bool Unsubscribed { get; set; }
        public DateTime UnsubscribedDate { get; set; }
    }
}
