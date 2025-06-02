namespace ContentGeneratorApp.Models
{
    public class Review
    {
        public string Name { get; set; } = null!;
        public string Text { get; set; } = null!;

        public override string ToString()
        {
            return $"{Text}\n- {Name}";
        }
    }
}
