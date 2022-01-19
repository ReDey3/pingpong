using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Converters.Abstractions
{
    public interface IBytesConverter<T>
    {
        public T Convert(byte[] bytes, int bytesReq);
    }
}
