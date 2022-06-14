
using QicFit.DTO;
using System;

namespace Common.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public int GenderId { get; set; }
        public bool AcceptUserAggrement { get; set; }
        public bool AcceptCovidAgreement { get; set; }
        public DateTime AcceptUserAggrementDate { get; set; }
        public DateTime AcceptCovidAgreementDate { get; set; }
        public GenderDTO Gender { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string AddressZipCode { get; set; }
        public double? AddressLat { get; set; }
        public double? AddressLng { get; set; }

        public SettingsDTO Settings { get; set; }

        public CityDTO City { get; set; }
        public StateDTO State { get; set; }
    }
}
