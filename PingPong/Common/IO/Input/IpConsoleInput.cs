using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Common.IO.Abstractions;

namespace Common.IO.Input
{
    public class IpConsoleInput : IInput<string>
    {
        public string GetInput()
        {
            IPAddress ip;
            string ipaddress = Console.ReadLine();
            while (!IPAddress.TryParse(ipaddress, out ip))
            {
                ipaddress = Console.ReadLine();
            }

            return ipaddress;
        }
    }
}
