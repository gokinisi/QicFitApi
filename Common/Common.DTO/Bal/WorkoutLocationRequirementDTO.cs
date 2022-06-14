using System;
using System.Collections.Generic;
using System.Text;

namespace QicFit.DTO
{
    public class WorkoutLocationRequirementDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Expiration { get; set; }
        public int WorkoutLocationId { get; set; }
    }
}
