
using Common.DTO;
using System.Collections.Generic;

namespace QicFit.DTO
{
    public class UserWorkoutDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkoutId { get; set; }
        public virtual WorkoutDTO Workout { get; set; }
        public virtual UserDTO User { get; set; }
 
    }
}
