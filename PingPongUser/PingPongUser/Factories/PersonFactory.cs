using Common;
using Common.IO.Abstractions;

namespace PingPongUser.Factories
{
    public class PersonFactory
    {
        private IInput<string> _input;
        private IInput<string> _numberInput;
        private IOutput<string> _output;

        public PersonFactory(IInput<string> input, IInput<string> numberInput, IOutput<string> output)
        {
            _input = input;
            _output = output;
            _numberInput = numberInput;
        }

        public Person Create()
        {
            _output.Output("Enter name:");
            string name = _input.GetInput();
            _output.Output("Enter age:");
            string age  = _numberInput.GetInput();

            return new Person(name, age);
        }
    }
}
