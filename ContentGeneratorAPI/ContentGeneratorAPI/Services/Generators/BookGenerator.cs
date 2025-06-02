using Bogus;
using ContentGeneratorAPI.Models;
using FluentRandomPicker;

namespace ContentGeneratorAPI.Services.Generators
{
    public class BookGenerator : IGenerator<Book>
    {
        public BookGenerator()
        {
        }

        public List<Book> GenerateList(LanguageEnum language, float likesCount, float reviewsCount, int page = 0, int n = 10)
        {
            var booksGen = new Faker<Book>(language.ToString())
                .RuleFor(i => i.Id, f => ++f.IndexVariable + page * n)
                .RuleFor(t => t.Title, f => GenerateTitle(f) )
                .RuleFor(i => i.Image, f => GenerateBookImage(f))
                .RuleFor(a => a.Author, f => GenerateAuthors(f, language))
                .RuleFor(p => p.Publisher, f => GeneratePublisher(language))
                .RuleFor(r => r.Reviews, f => GenerateChanceReviews(f, language, reviewsCount))
                .RuleFor(l => l.Likes, f => GenerateChanceLikes(f, likesCount))
                .RuleFor(i => i.Isbn, f => f.Random.Replace("978-#-##-######-#"))
                .RuleFor(l => l.Language, language);

            return booksGen.Generate(n);
        }

        private string GenerateTitle(Faker f)
        {
            List<string> titleOptions = new List<string>
            {
                f.Commerce.Product(),
                $"{f.Name.FirstName()} {f.Commerce.Product()}",
                $"{f.Address.City()} {f.Hacker.IngVerb()}"
            };
            return f.PickRandom(titleOptions);
        }


        private int GenerateChanceLikes(Faker f, float count)
        {
            int integerCount = (int)count;
            return f.Random.Float(0f, 0.99f) < count - integerCount ? integerCount + 1: integerCount;
        }

        private List<Review> GenerateChanceReviews(Faker f, LanguageEnum language, float count)
        {
            ReviewGenerator generator = new ReviewGenerator(f);
            int integerCount = (int)count;
            List<Review> reviews = generator.GenerateList(language, integerCount);
            if (f.Random.Float(0f, 0.99f) < count - integerCount)
            {
                reviews.AddRange(generator.GenerateList(language, 1));
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
                new AuthorGenerator().GenerateList(language, 1) :
                new AuthorGenerator().GenerateList(language, 2);
        }

        private string GenerateBookImage(Faker f)
        {
            return $"https://picsum.photos/200/300?random={f.Random.Int(1,1000)}";
        }

        public List<Book> GenerateList(LanguageEnum language, int n)
        {
            throw new NotImplementedException();
        }
    }
}