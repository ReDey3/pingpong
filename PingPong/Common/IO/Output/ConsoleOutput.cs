using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.IO.Output
{
    public class ConsoleOutput : Abstractions.IOutput<string>
    {
        public void Output(string input)
        {
            Console.WriteLine(input);
        }
    }
}
