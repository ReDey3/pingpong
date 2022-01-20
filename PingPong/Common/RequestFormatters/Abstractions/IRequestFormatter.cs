namespace Common.RequestFormatters.Abstractions
{
    public interface IRequestFormatter<T>
    {
        // will return the action name and other info needed for it
        public IDictionary<string,T> FormatRequest(T input);
    }
}
