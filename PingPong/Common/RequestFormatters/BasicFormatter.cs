using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common.RequestFormatters
{
    public class BasicFormatter : Abstractions.IRequestFormatter<string>
    {
        public IDictionary<string,string> FormatRequest(string input)
        {
            return new Dictionary<string, string> { { "SendBackToUser", input } }; // TODO: should use config here
        }
    }
}
