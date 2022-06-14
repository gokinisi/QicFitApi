using Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QicFit.Entities
{
    public class AgeGroup : BaseEntity
    {
        public string Range { get; set; }
        public int Order { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
