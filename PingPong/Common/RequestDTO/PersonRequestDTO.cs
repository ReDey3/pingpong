using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestDTO
{
    public class PersonRequestDTO
    {
        private Person _person;
        private string _msg;
        public override string ToString()
        {
            return $"{_person.ToString()}   {_msg}";
        }
    }
}
