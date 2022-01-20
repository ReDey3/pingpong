namespace Common
{
    [Serializable]
    public class Person
    {
        private string _name;
        private string _age;

        
        public Person(string name, string age)
        {
            _name = name;
            _age = age; 
        }

        public override string ToString()
        {
            return $"{_name} is {_age} years old.";
        }
    }
}