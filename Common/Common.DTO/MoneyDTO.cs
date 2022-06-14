
namespace Common.DTO
{
    public class MoneyDTO
    {
        public MoneyDTO(decimal value, string currency)
        {
            Value = value;
            Currency = currency;
        }

        public decimal Value { get; }
        public string Currency { get; }
    }
}
