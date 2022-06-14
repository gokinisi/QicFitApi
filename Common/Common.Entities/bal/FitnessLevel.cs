using Common.Entities;
using System.Collections.Generic;

namespace QicFit.Entities
{
    public class FitnessLevel : BaseEntity
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public int WorkoutTypeId { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }

        public virtual WorkoutType WorkoutType { get; set; }
    }
}
