using System.Runtime.Serialization.Formatters.Binary;
using Common.Converters.Abstractions;

namespace Common.Converters
{
    public class ObjectToBytes : IObjectConverter<byte[]>
    {
        public byte[] Convert(object dataToConvert)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, dataToConvert);
                return ms.ToArray();
            }
        }
    }
}
