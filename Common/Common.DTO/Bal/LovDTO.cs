using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QicFit.DTO
{
    public class LovDTO
    {
        public LovDTO()
        {
            this.GenderLOV = Enumerable.Empty<GenderDTO>();
            this.RadiusLOV = Enumerable.Empty<RadiusDTO>();
            this.WorkoutTypeLOV = Enumerable.Empty<WorkoutTypeDTO>();
            this.AgeGroupLOV = Enumerable.Empty<AgeGroupDTO>();
            this.WorkoutLocationLOV = Enumerable.Empty<WorkoutCityGroupDTO>();
        }

        public IEnumerable<GenderDTO> GenderLOV { get; set; }
        public IEnumerable<RadiusDTO> RadiusLOV { get; set; }
        public IEnumerable<WorkoutTypeDTO> WorkoutTypeLOV { get; set; }
        public IEnumerable<AgeGroupDTO> AgeGroupLOV { get; set; }
        public IEnumerable<WorkoutCityGroupDTO> WorkoutLocationLOV { get; set; }

        public IEnumerable<CityDTO> CityLOV { get; set; }
        public IEnumerable<StateDTO> StateLOV { get; set; }

    }
}
