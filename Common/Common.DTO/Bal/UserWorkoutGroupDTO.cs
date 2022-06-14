using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace QicFit.DTO
{
    public class UserWorkoutGroupDTO
    {

        public UserWorkoutGroupDTO()
        {
            this.WorkoutGroup = new WorkoutGroupDTO();

        }
        public int Id { get; set; }
        public WorkoutGroupDTO WorkoutGroup { get; set; }
    }
}
