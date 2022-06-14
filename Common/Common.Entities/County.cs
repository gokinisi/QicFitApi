
using QicFit.Entities;
using System.Collections.Generic;

namespace Common.Entities
{
    public class County : BaseEntity
    {
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }

    }
}