using Common.DTO;
using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QicFit.DTO
{
    public class WorkoutGroupDTO
    {
        public WorkoutGroupDTO()
        {
            this.Workouts = Enumerable.Empty<WorkoutDTO>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<WorkoutDTO> Workouts { get; set; }

    }
}
