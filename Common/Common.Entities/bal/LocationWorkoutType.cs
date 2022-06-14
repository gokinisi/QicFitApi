using Common.Entities;
using QicFit.Entities.System;
using System.Collections.Generic;

namespace QicFit.Entities
{
    public class LocationWorkoutType : BaseTrackableEntity
    {
        public int LocationId { get; set; }
        public int WorkoutTypeId { get; set; }

        public virtual WorkoutType WorkoutType { get; set; }
        public virtual WorkoutLocation Location { get; set; }
    }
}
