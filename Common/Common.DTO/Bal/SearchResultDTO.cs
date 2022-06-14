using System;
using System.Collections.Generic;
using System.Text;

namespace QicFit.DTO
{
    public class SearchResultDTO
    {
        public WorkoutDTO Workout { get; set; }
        public IEnumerable<UserWorkoutDTO> UserWorkOut { get; set; }
    }
}
