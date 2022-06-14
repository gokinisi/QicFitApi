
using Common.Entities;
using System.Collections.Generic;

namespace QicFit.Entities
{
    public class Contact : BaseTrackableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberType { get; set; }
        public virtual ContactPhoto Photo { get; set; }
      }
}
