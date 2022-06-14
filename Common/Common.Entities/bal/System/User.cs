
using Common.Entities;
using System.Collections.Generic;

namespace QicFit.Entities.System
{
    public class User : BaseUser
    {
        public virtual IEnumerable<UserWorkout> UserWorkout { get; set; }

        public virtual IEnumerable<UserLocation> UserLocations { get; set; }
    }
}
