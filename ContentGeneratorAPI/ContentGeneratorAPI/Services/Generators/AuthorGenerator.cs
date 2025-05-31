using Bogus;
using ContentGeneratorAPI.Models;

namespace ContentGeneratorAPI.Services.Generators
{
    public class AuthorGenerator : IGenerator<Author>
    {
        public List<Author> GenerateList(LanguageEnum language, int n)
        {
            var authorGen = new Faker<Author>(language.ToString())
               .RuleFor(n => n.Name, f => f.Name.FullName());
            return authorGen.Generate(n);
        }

    }
}
