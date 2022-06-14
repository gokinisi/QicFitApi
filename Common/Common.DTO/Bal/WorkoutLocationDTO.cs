using System.Collections.Generic;
using System.Linq;

namespace QicFit.DTO
{
    public class WorkoutLocationDTO
    {
        public WorkoutLocationDTO()
        {
            this.WorkoutLocationRequirement = Enumerable.Empty<WorkoutLocationRequirementDTO>();
            this.City = new CityDTO();
            this.State = new StateDTO();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string ZipCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public CityDTO City { get; set; }
        public StateDTO State { get; set; }
        public IEnumerable<WorkoutLocationRequirementDTO> WorkoutLocationRequirement { get; set; }
    }
}
