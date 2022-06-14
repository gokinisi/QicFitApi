using Common.Entities;
using System.Collections.Generic;

namespace QicFit.Entities
{
    public class Radius : BaseEntity
    {
        public string Range { get; set; }
        public int Order { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
