using Common.Entities;
using QicFit.Entities.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace QicFit.Entities
{
    public class Workout : BaseTrackableEntity
    {
        public string Name { get; set; }
        
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public int WorkoutLocationId { get; set; }
        public int GenderId { get; set; }
        public int AgeGroupId { get; set; }
        public int RadiusId { get; set; }
        public int WorkoutTypeId { get; set; }
        public int FitnessLevelId { get; set; }

        public virtual WorkoutLocation WorkoutLocation { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual AgeGroup AgeGroup { get; set; }
        public virtual Radius Radius { get; set; }
        public virtual WorkoutType WorkoutType { get; set; }
        public virtual FitnessLevel FitnessLevel { get; set; }

        public virtual IEnumerable<UserWorkout> UserWorkout { get; set; }
    }
}
