using Bogus;
using ContentGeneratorAPI.Models;

namespace ContentGeneratorAPI.Services.Generators
{
    public class BookGenerator : IGenerator<Book>
    {
        public List<Book> GenerateList(LanguageEnum language, float likesCount, float reviewsCount, int n = 10)
        {
            var booksGen = new Faker<Book>(language.ToString())
                .RuleFor(i => i.Id, f => f.UniqueIndex)
                .RuleFor(t => t.Title, f => f.Commerce.ProductName())
                .RuleFor(i => i.Image, GenerateBookImage())
                .RuleFor(a => a.Author, f => GenerateAuthors(f, language))
                .RuleFor(p => p.Publisher, f => GeneratePublisher(language))
                .RuleFor(r => r.Reviews, f => GenerateChanceReviews(f, language, reviewsCount))
                .RuleFor(l => l.Likes, f => GenerateChanceLikes(f, likesCount))
                .RuleFor(i => i.Isbn, f => f.Random.Replace("978-3-16-148410-0"));
            return booksGen.Generate(n);
        }

        private int GenerateChanceLikes(Faker f, float count)
        {
            int integerCount = (int)Math.Floor(count);
            return f.Random.Float(1) < count - integerCount ? integerCount + 1 : integerCount;
        }

        private List<Review> GenerateChanceReviews(Faker f, LanguageEnum language, float count)
        {
            ReviewGenerator generator = new ReviewGenerator();
            int integerCount = (int)Math.Floor(count);
            List<Review> reviews = generator.GenerateList(language, integerCount);
            if (f.Random.Float(1) < count - integerCount)
            {
                reviews.AddRange(generator.GenerateList(language,1));
            }
            return reviews;
        }

        private Publisher GeneratePublisher(LanguageEnum language)
        {
            return new PublisherGenerator().GenerateList(language, 1).First();
        }

        private List<Author> GenerateAuthors(Faker f, LanguageEnum language)
        {
            return f.Random.Int(1, 2) == 1 ?
                new AuthorGenerator().GenerateList(language, 1):
                new AuthorGenerator().GenerateList(language, 2);
        }

        private string GenerateBookImage()
        {
            return $"https://picsum.photos/200/300?random={new Random().Next(1, 1000)}";
        }

        public List<Book> GenerateList(LanguageEnum language, int n)
        {
            throw new NotImplementedException();
        }
    }
}
