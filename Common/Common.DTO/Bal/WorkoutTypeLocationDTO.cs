
using Common.DTO;
using System.Collections.Generic;

namespace QicFit.DTO
{
    public class LocationWorkoutTypeConfig
    {
        public int Id { get; set; }
        public WorkoutTypeDTO WorkoutType { get; set; }

        public WorkoutLocationDTO Location { get; set; }
 
    }
}
