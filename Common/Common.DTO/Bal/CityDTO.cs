using System;
using System.Collections.Generic;
using System.Text;

namespace QicFit.DTO
{
    public class CityDTO
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string County { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int StateId { get; set; }
        public virtual StateDTO State { get; set; }

    }
}
