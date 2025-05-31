using ContentGeneratorAPI.Models;

namespace ContentGeneratorAPI.Services.Generators
{
    public interface IGenerator<T> where T : class
    {
        /// <summary>
        /// Generates fake records list of the object
        /// </summary>
        /// <param name="n">quantity of objects</param>
        /// <returns></returns>
        List<T> GenerateList(LanguageEnum language, int n);
    }
}
