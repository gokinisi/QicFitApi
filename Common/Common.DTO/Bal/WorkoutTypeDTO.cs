using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QicFit.DTO
{
    public class WorkoutTypeDTO
    {

        public WorkoutTypeDTO()
        {
            this.FitnessLevels = Enumerable.Empty<FitnessLevelDTO>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public int Order { get; set; }

        public IEnumerable<FitnessLevelDTO> FitnessLevels { get; set; }
    }
}
