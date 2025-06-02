using Bogus;
using ContentGeneratorAPI.Models;
using FluentRandomPicker;

namespace ContentGeneratorAPI.Services.Generators
{
    public class ReviewGenerator : IGenerator<Review>
    {
        private readonly List<string>? _reviewOptions;
        public ReviewGenerator() { }
        public ReviewGenerator(Faker f)
        {
            _reviewOptions = new List<string>
            {
                $"{f.Commerce.ProductName()} {f.Commerce.ProductAdjective()}!",
                $"{f.Company.CompanyName()} {f.Company.CatchPhrase()}",
                $"{f.Company.CompanyName()} {f.Hacker.IngVerb()} {f.Commerce.ProductAdjective()}"
            };
        }
        public List<Review> GenerateList(LanguageEnum language, int n)
        {
            var reviewsGen = new Faker<Review>(language.ToString())
                .RuleFor(n => n.Name, f => f.Internet.UserName())
                .RuleFor(t => t.Text, f => RandomReviewSentence(f));
            return reviewsGen.Generate(n);
        }

        public string RandomReviewSentence(Faker f)
        {           
            return f.PickRandom(_reviewOptions);
        }
    }
}
