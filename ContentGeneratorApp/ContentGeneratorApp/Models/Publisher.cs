using Microsoft.VisualBasic;

namespace ContentGeneratorAPI.Models
{
    public class Publisher
    {
        public string Name { get; set; } = null!;
        public uint Year { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Year}";
        }
    }
}
