using System.Text;

namespace Common.Converters
{
    public class BytesToStringConverter : Abstractions.IBytesConverter<string>
    {
        public string Convert(byte[] bytes, int bytesReq)
        {
            return Encoding.ASCII.GetString(bytes, 0, bytesReq);
        }
    }
}
