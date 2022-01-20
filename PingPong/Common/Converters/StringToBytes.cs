using System.Text;
using Common.Converters.Abstractions;

namespace Common.Converters
{
    public class StringToBytes : IStringConverter<byte[]>
    {
        public byte[] Convert(string dataToConvert)
        {
            return Encoding.ASCII.GetBytes(dataToConvert);
        }
    }
}
