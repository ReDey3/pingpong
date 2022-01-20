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
