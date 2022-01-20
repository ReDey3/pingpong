using System.Runtime.Serialization.Formatters.Binary;
using Common.Converters.Abstractions;


namespace Common.Converters
{
    public class BytesToObject : IBytesConverter<object>
    {
        public object Convert(byte[] bytes, int bytesReq)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(bytes, 0, bytesReq);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }
    }
}
