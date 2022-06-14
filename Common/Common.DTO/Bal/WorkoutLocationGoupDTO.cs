using System.Collections.Generic;
using System.Linq;

namespace QicFit.DTO
{
    public class WorkoutCityGroupDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<WorkoutLocationGroupDTO> WorkoutLocations { get; set; }

    }

    public class WorkoutLocationGroupDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }

    }
}
