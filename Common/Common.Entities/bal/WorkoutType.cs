using Common.Entities;
using System.Collections.Generic;

namespace QicFit.Entities
{
    public class WorkoutType : BaseEntity
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }
        public virtual ICollection<LocationWorkoutType> LocationWorkoutType { get; set; }
        public virtual ICollection<FitnessLevel> FitnessLevels { get; set; }

    }
}
