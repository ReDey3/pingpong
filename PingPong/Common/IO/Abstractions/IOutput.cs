namespace Common.IO.Abstractions
{
    public interface IOutput<T>
    {
        public void Output(T input);
    }
}
