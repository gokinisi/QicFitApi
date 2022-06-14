
namespace Common.DTO
{
    public class AddressDTO
    {
        public AddressDTO() { }

        public AddressDTO(string zipCode, int cityId, double? lat, double? lng, int stateId)
        {
            StateId = stateId;
            ZipCode = zipCode;
            CityId = cityId;
            Lat = lat;
            Lng = lng;
        }

        public int StateId { get; set; }

        public int CityId { get; set; }
        public string ZipCode { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
    }
}
