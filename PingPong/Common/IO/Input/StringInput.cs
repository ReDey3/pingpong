namespace Common.IO.Input
{
    public class StringInput : Abstractions.IInput<string>
    {
        public string GetInput()
        {
            string? input = Console.ReadLine();
            while (input == null)
            {
                input = Console.ReadLine();
            }
            return input; 
        }
    }
}
