using Common.Entities;
using QicFit.Entities.System;
using System.Collections.Generic;

namespace QicFit.Entities
{
    public class UserLocation : BaseTrackableEntity
    {

        public int UserId { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }

        public virtual User User {get; set;}
        public virtual City City { get; set; }
        public virtual State State { get; set; }

    }
}
