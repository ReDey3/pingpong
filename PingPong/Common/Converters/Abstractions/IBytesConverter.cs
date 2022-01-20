namespace Common.Converters.Abstractions
{
    public interface IBytesConverter<T>
    {
        public T Convert(byte[] bytes, int bytesReq);
    }
}
