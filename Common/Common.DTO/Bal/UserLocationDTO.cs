using Common.DTO;
using System.Collections.Generic;
using System.Linq;

namespace QicFit.DTO
{
    public class UserLocationDTO
    {
        public int Id { get; set; }
        //public int UserId { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }

        public virtual UserDTO User { get; set; }
        public virtual CityDTO City { get; set; }
        public virtual StateDTO State { get; set; }

    }
}
