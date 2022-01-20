using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.IO.Abstractions;

namespace Common.IO.Input
{
    public class NumberConsoleInput : IInput<string>
    {
        public string GetInput()
        {
            int parsedInt;
            string numberInput = Console.ReadLine();
            while (!int.TryParse(numberInput, out parsedInt))
            {
                numberInput = Console.ReadLine();
            }
            return numberInput;
        }
    }
}
