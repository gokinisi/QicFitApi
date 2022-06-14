using Common.Entities;
using QicFit.Entities.System;
using System.Collections.Generic;

namespace QicFit.Entities
{
    public class UserWorkout : BaseTrackableEntity
    {
        public int UserId { get; set; }
        public int WorkoutId { get; set; }

        public virtual Workout Workout { get; set; }
        public virtual User User { get; set; }
    }
}
