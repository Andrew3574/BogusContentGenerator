using Bogus;
using ContentGeneratorAPI.Models;

namespace ContentGeneratorAPI.Services.Generators
{
    public class ReviewGenerator : IGenerator<Review>
    {
        public List<Review> GenerateList(LanguageEnum language, int n)
        {
            var reviewsGen = new Faker<Review>(language.ToString())
                .RuleFor(n => n.Name, f => f.Internet.ToString())
                .RuleFor(t => t.Text, f => f.Rant.ToString());
            return reviewsGen.Generate(n);
        }
    }
}
