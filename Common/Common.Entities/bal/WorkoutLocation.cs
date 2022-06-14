
using Common.Entities;
using QicFit.Entities.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace QicFit.Entities
{
    public class WorkoutLocation : BaseTrackableEntity
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Workout> Workout { get; set; }
        public virtual ICollection<LocationWorkoutType> LocationWorkoutType { get; set; }
        public virtual ICollection<WorkoutLocationRequirement> Requirement { get; set; }
        public virtual City City { get; set; }
        public virtual State State { get; set; }

    }
}
