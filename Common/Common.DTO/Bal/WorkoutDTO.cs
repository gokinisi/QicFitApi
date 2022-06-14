using Common.DTO;
using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace QicFit.DTO
{
    public class WorkoutDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenderId { get; set; }
        public int AgeGroupId { get; set; }
        public int WorkoutLocationId { get; set; }
        public int WorkoutTypeId { get; set; }
        public int FitnessLevelId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public int RadiusId { get; set; }
        public bool AlreadySignedUp { get; set; }

        public IEnumerable<UserDTO> Participants { get; set; }
        public virtual WorkoutLocationDTO WorkoutLocation { get; set; }
        public virtual AgeGroupDTO AgeGroup { get; set; }
        public virtual GenderDTO Gender { get; set; }
        public virtual WorkoutTypeDTO WorkoutType { get; set; }
        public virtual FitnessLevelDTO FitnessLevel { get; set; }

    }
}
