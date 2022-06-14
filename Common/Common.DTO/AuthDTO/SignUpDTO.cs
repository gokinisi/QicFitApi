
using System;

namespace Common.DTO
{
    public class SignUpDTO : LoginDTO
    {
        public string FullName { get; set; }
        public string ConfirmPassword { get; set; }
        public int Age { get; set; }
        public int GenderId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public bool AcceptCovidAgreement { get; set; }
        public bool AcceptUserAgreement { get; set; }
        public DateTime AcceptCovidAgreementDate { get; set; }
        public DateTime AcceptUserAgreementDate { get; set; }
    }
}