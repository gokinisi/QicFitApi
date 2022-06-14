using Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QicFit.Entities
{
    public class WorkoutLocationRequirement: BaseTrackableEntity
    {
        public string Name { get; set; }
        public DateTime Expiration { get; set; }
        public int WorkoutLocationId { get; set; }
        public virtual WorkoutLocation WorkoutLocation { get; set; }
    }
}
