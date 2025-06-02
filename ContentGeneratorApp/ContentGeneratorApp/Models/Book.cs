using ContentGeneratorAPI.Models;

namespace ContentGeneratorApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Image { get; set; } = null!;
        public Publisher Publisher { get; set; } = null!;
        public List<Author> Author { get; set; } = null!;
        public List<Review>? Reviews { get ; set; }
        public int Likes { get; set; }
        public string Isbn { get; set; } = null!;
        public LanguageEnum Language { get; set; }

        
    }
}
