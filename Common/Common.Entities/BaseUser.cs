
using QicFit.Entities;
using System;
using System.Collections.Generic;

namespace Common.Entities
{
    public abstract class BaseUser : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public int GenderId { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string AddressZipCode { get; set; }
        public double? AddressLat { get; set; }
        public double? AddressLng { get; set; }
        public bool AcceptUserAgreement { get; set; }
        public bool AcceptCovidAgreement { get; set; }
        public DateTime AcceptUserAgreementDate { get; set; }
        public DateTime AcceptCovidAgreementDate { get; set; }
        public virtual UserPhoto Photo { get; set; }
        //public virtual Settings Settings { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual ICollection<BaseUserRole> UserRoles { get; set; }
        public virtual ICollection<BaseUserClaim> Claims { get; set; }

        public virtual City City { get; set; }
        public virtual State State { get; set; }
    }
}
