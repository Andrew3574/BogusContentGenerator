using Bogus;
using ContentGeneratorAPI.Models;

namespace ContentGeneratorAPI.Services.Generators
{
    public class PublisherGenerator : IGenerator<Publisher>
    {
        public List<Publisher> GenerateList(LanguageEnum language, int n)
        {
            var publisherGen = new Faker<Publisher>(language.ToString())
              .RuleFor(n => n.Name, f => f.Name.FullName())
              .RuleFor(y => y.Year, f => f.Random.UInt(1990, 2025));
            return publisherGen.Generate(n);
        }
    }
}
