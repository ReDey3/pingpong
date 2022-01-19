using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
