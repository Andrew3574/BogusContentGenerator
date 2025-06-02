namespace ContentGeneratorAPI.Models
{
    public class Author
    {
        public string Name { get; set; } = null!;

        public override string ToString()
        {
            return Name;
        }
    }
}
