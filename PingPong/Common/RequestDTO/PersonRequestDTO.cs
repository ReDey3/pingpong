using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestDTO
{
    [Serializable]
    public class PersonRequestDTO
    {
        private Person _person;
        private string _msg;

        public PersonRequestDTO(Person person, string msg)
        {
            _person = person;
            _msg = msg;
        }

        public override string ToString()
        {
            return $"{_person.ToString()} #Message===> {_msg}";
        }
    }
}
