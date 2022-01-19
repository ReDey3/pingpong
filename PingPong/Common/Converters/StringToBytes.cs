using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
