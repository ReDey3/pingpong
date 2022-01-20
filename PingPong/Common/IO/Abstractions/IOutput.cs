using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.IO.Abstractions
{
    public interface IOutput<T>
    {
        public void Output(T input);
    }
}
