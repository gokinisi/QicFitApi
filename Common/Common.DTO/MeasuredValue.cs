namespace Common.DTO
{
    public class MeasuredValue<T>
    {
        public MeasuredValue(T value, string uom)
        {
            Value = value;
            UnitOfMeasure = uom;
        }

        public T Value { get; }
        public string UnitOfMeasure { get; }
    }
}
