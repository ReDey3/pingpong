namespace Common.Converters.Abstractions
{
    public interface IObjectConverter<T>
    {
        public T Convert(object dataToConvert);
    }
}
