
using QicFit.Entities;
using System.Collections.Generic;

namespace Common.Entities
{
    public class State : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual IEnumerable<City> City { get; set; }

        public virtual IEnumerable<UserLocation> UserLocations { get; set; }

    }
}