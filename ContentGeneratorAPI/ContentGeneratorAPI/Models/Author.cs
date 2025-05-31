namespace ContentGeneratorAPI.Models
{
    public class Author
    {
        private string _name = null!;

        public Author() { }
        public Author(string name)
        {
            _name = name;
        }

        public string Name { get { return _name; } }
    }
}
