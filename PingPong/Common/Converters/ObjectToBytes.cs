using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
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
