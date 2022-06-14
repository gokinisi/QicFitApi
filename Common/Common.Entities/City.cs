
using QicFit.Entities;
using System.Collections.Generic;

namespace Common.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public string County { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int StateId { get; set; }
        public bool Active { get; set; }
        public virtual State State { get; set; }

        public virtual IEnumerable<UserLocation> UserLocations { get; set; }

        public virtual IEnumerable<County> Counties { get; set; }

    }
}