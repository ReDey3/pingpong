namespace Common.Converters.Abstractions
{
    public interface IStringConverter<T>
    {
        public T Convert(string dataToConvert);
    }
}
