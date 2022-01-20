using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common.RequestFormatters
{
    public class BasicFormatter : Abstractions.IRequestFormatter<object>
    {
        public IDictionary<string, object> FormatRequest(object input)
        {
            return new Dictionary<string, object> { { "SendBackToUser", input.ToString() } };
        }
    }
}
