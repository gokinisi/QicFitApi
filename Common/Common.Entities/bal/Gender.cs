using Common.Entities;
using QicFit.Entities.System;
using System.Collections.Generic;

namespace QicFit.Entities
{
    public class Gender : BaseEntity
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
